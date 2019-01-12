//using Helezon.FollowMe.WebUI.Models.ViewModels;
//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace Helezon.FollowMe.WebUI.MyModelBinders
//{
//    public class ZetaCodeNormalIplikVmBinder : IModelBinder
//    {
//        private decimal MyNumberParse(string value)
//        {
//            try
//            {
//                return decimal.Parse(value, NumberStyles.Any, CultureInfo.InvariantCulture);
//            }
//            catch (Exception)
//            {

//                return decimal.Zero;
//            }
//        }

//        public object BindModel(ControllerContext controllerContext,
//        ModelBindingContext bindingContext)
//        {
//            ZetaCodeNormalIplikVm model = (ZetaCodeNormalIplikVm)bindingContext.ModelMetadata.Model
//            ?? new ZetaCodeNormalIplikVm();
//            model.IplikKategoriDegrede.BoyamaProsesi = MyNumberParse(GetValue(bindingContext, "IplikKategoriDegrede.BoyamaProsesiFormat"));
//            model.IplikKategoriFlam.FlamlarArasindakiMesafe = MyNumberParse(GetValue(bindingContext, "IplikKategoriFlam.FlamlarArasindakiMesafeFormat"));
//            model.IplikKategoriFlam.FlamUzunlugu = MyNumberParse(GetValue(bindingContext, "IplikKategoriFlam.FlamUzunluguFormat"));
//            model.IplikKategoriFlam.FlamYuksekligi = MyNumberParse(GetValue(bindingContext, "IplikKategoriFlam.FlamYuksekligiFormat"));
//            model.IplikKategoriKircili.KircillarArasiMesafe = MyNumberParse(GetValue(bindingContext, "IplikKategoriKircili.KircillarArasiMesafeFormat"));
//            model.IplikKategoriKircili.KircilUzunlugu = MyNumberParse(GetValue(bindingContext, "IplikKategoriKircili.KircilUzunluguFormat"));
//            model.IplikKategoriKircili.KircilYuksekligi = MyNumberParse(GetValue(bindingContext, "IplikKategoriKircili.KircilYuksekligiFormat"));
//            model.IplikKategoriKrep.TurSayisi = (int)MyNumberParse(GetValue(bindingContext, "IplikKategoriKrep.TurSayisiFormat"));
//            model.IplikKategoriNopeli.NoktalarArasiMesafe = MyNumberParse(GetValue(bindingContext, "IplikKategoriKrep.NoktalarArasiMesafeFormat"));
//            model.IplikKategoriNopeli.NoktaUzunlugu = MyNumberParse(GetValue(bindingContext, "IplikKategoriKrep.NoktaUzunluguFormat"));
//            model.IplikKategoriNopeli.NoktaYuksekligi = MyNumberParse(GetValue(bindingContext, "IplikKategoriKrep.NoktaYuksekligiFormat"));

//            //model.Country = GetValue(bindingContext, "Country");
//            return model;
//        }
//        private string GetValue(ModelBindingContext context, string name)
//        {
//            name = (context.ModelName == "" ? "" : context.ModelName + ".") + name;
//            ValueProviderResult result = context.ValueProvider.GetValue(name);
//            if (result == null || result.AttemptedValue == "")
//            {
//                return "<Not Specified>";
//            }
//            else
//            {
//                return (string)result.AttemptedValue;
//            }
//        }
//    }
//}