﻿using Helezon.FollowMe.Entities.Models;
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
    public interface IZetaCodeFanteziIplikPictureService : IService<ZetaCodeFanteziIplikPicture>
    {
        string GetZetaCodeFanteziIplikPictureUrl(int id, string companyId);
        void DeleteByImageName(string imageName);
        void SetFeaturedPicture(string pictureName);
        List<ZetaCodeFanteziIplikPicture> GetAllById(int id, string companyId);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class ZetaCodeFanteziIplikPictureService : Service<ZetaCodeFanteziIplikPicture>, IZetaCodeFanteziIplikPictureService
    {
        private readonly IRepositoryAsync<ZetaCodeFanteziIplikPicture> _repository;
        public ZetaCodeFanteziIplikPictureService(IRepositoryAsync<ZetaCodeFanteziIplikPicture> repository) : base(repository)
        {
            _repository = repository;
        }

        public string GetZetaCodeFanteziIplikPictureUrl(int id,string companyId)
        {
            var pitureName =  _repository.GetZetaCodeFanteziIplikPictureName(id, companyId);
            if (string.IsNullOrWhiteSpace(pitureName))            
                return "/Files/Uploaded/images/noimage.png";

            return "/Files/Uploaded/images/" + pitureName + "250x300.jpg";
        }
 
        public override void Update(ZetaCodeFanteziIplikPicture entity)
        {
            base.Update(entity);
        }

        public List<ZetaCodeFanteziIplikPicture> GetAllById(int id,string companyId)
        {
            return _repository.GetAll(id, companyId);
        }


        public override void Insert(ZetaCodeFanteziIplikPicture entity)
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

        private void ResetAllFeaturedPicture(int id,string companyId)
        {
            var featuredPictures = _repository.GetAllByFeatured(id, companyId);
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
                ResetAllFeaturedPicture(picture.Id,picture.CompanyId);
                picture.IsFeatured = true;
                this.Update(picture);
            }
        }

    }
}
