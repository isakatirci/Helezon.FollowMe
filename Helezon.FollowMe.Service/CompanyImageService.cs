using Helezon.FollowMe.Entities.Models;
using Helezon.FollowMe.Repository.Repositories;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helezon.FollowMe.Service
{
    /// <summary>
    ///     Add any custom business logic (methods) here
    /// </summary>
    public interface ICompanyPictureService : IService<CompanyPicture>
    {
        string GetCompanyPictureName(string companyId);
        void DeleteByImageName(string imageName);
        void SetFeaturedPicture(string pictureName);
        List<CompanyPicture> GetAllByCompanyId(string companyId);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class CompanyPictureService : Service<CompanyPicture>, ICompanyPictureService
    {
        private readonly IRepositoryAsync<CompanyPicture> _repository;
        public CompanyPictureService(IRepositoryAsync<CompanyPicture> repository) : base(repository)
        {
            _repository = repository;
        }

        public string GetCompanyPictureName(string companyId)
        {
            var pitureName =  _repository.GetCompanyPictureName(companyId);
            if (string.IsNullOrWhiteSpace(pitureName))            
                return "/Files/Uploaded/images/noimage.png";

            return "/Files/Uploaded/images/" + pitureName + "250x300.jpg";
        }
 
        public override void Update(CompanyPicture entity)
        {
            base.Update(entity);
        }

        public List<CompanyPicture> GetAllByCompanyId(string companyId)
        {
            return _repository.GetAll(companyId);
        }


        public override void Insert(CompanyPicture entity)
        {
            // e.g. add business logic here before inserting
            base.Insert(entity);
        }

        public override void Delete(object id)
        {
            // e.g. add business logic here before deleting
            base.Delete(id);
        }

        public void DeleteByImageName(string imageName)
        {
            var deletingImage = _repository.GetByPictureName(imageName);
            if (deletingImage != null && !deletingImage.IsPassive)
            {
                deletingImage.IsPassive = true;
                this.Update(deletingImage);
            }
        }

        private void ResetAllFeaturedPicture(string companyId)
        {
            var featuredPictures = _repository.GetAllByFeatured(companyId);
            if (featuredPictures != null)
            {
                foreach (var picture in featuredPictures)
                {
                    picture.IsFeatured = false;
                    this.Update(picture);
                }              
            }
        }
        public void SetFeaturedPicture(string pictureName)
        {
            var picture = _repository.GetByPictureName(pictureName);
            if (picture != null && !picture.IsFeatured)
            {
                ResetAllFeaturedPicture(picture.CompanyId);
                picture.IsFeatured = true;
                this.Update(picture);
            }
        }

    }
}
