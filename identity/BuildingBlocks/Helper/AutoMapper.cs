using System;
using System.Collections.Generic;

namespace Construxiv.BuildingBlocks.Helper
{
    public class AutoMapper
    {
        /// <summary>
        /// Cap nhat model tu DTO co mask
        /// </summary>
        /// <typeparam name="M"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="dto"></param>
        public static void UpdateFrom<M, T>(M model, T dto)
        {
            var property = dto.GetType().GetProperty("Mask");
            // nếu DTO ko có mask thì gọi hàm ko mask
            if (property == null)
            {
                UpdateModelNotMask<M, T>(model, dto);
                return;
            }
            var dtoMask = property.GetValue(dto);
            int iDTOMask = Convert.ToInt32(dtoMask);
            var maskType = property.PropertyType;
            foreach (var mask in Enum.GetValues(maskType))
            {
                int iMask = Convert.ToInt32(mask);

                if ((iMask & iDTOMask) == iMask)
                {
                    string memberName = mask.ToString();
                    // bo qua truong Id ko update tu DTO
                    if (memberName == "Id") continue;
                    var dataProperty = dto.GetType().GetProperty(memberName);
                    if (dataProperty == null) continue;
                    var modelProperty = model.GetType().GetProperty(memberName);
                    if (modelProperty == null) continue;
                    // Property trùng tên nhưng khác kiểu thì cũng ko copy
                    // Xử lý cho t/h model chứa model -> dto chứa dto hoặc ngược lại
                    // lúc này ko cần đặt tên nhưng dto nested khác với model nested
                    if (dataProperty.PropertyType != modelProperty.PropertyType) continue;
                    modelProperty.SetValue(model, dataProperty.GetValue(dto));
                }
            }
        }

        /// <summary>
        /// Cap nhat model ma DTO ko co truong mask
        /// </summary>
        /// <typeparam name="M"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="dto"></param>
        public static void UpdateModelNotMask<M, T>(M model, T dto)
        {
            foreach (var pro in dto.GetType().GetProperties())
            {
                string memberName = pro.Name;
                // bo qua truong Id ko update tu DTO
                if (memberName == "Id") continue;
                var modelProperty = model.GetType().GetProperty(memberName);
                if (modelProperty == null) continue;
                // Property trùng tên nhưng khác kiểu thì cũng ko copy
                // Xử lý cho t/h model chứa model -> dto chứa dto hoặc ngược lại
                // lúc này ko cần đặt tên nhưng dto nested khác với model nested
                if (pro.PropertyType != modelProperty.PropertyType) continue;
                modelProperty.SetValue(model, pro.GetValue(dto));
            }
        }

        /// <summary>
        /// Tao DTO tu model
        /// </summary>
        /// <typeparam name="M"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static T CreateDTO<M, T>(M model) where T : new()
        {
            if (model == null)
                return default(T);
            T dto = new T();
            foreach (var pro in dto.GetType().GetProperties())
            {
                string memberName = pro.Name;
                var modelProperty = model.GetType().GetProperty(memberName);
                if (modelProperty == null) continue;
                // Property trùng tên nhưng khác kiểu thì cũng ko copy
                // Xử lý cho t/h model chứa model -> dto chứa dto hoặc ngược lại
                // lúc này ko cần đặt tên nhưng dto nested khác với model nested
                if (pro.PropertyType != modelProperty.PropertyType) continue;
                pro.SetValue(dto, modelProperty.GetValue(model));
            }
            return dto;
        }

        /// <summary>
        /// Tao danh sach DTO tu model: cho cac ham tra ve list item
        /// </summary>
        /// <typeparam name="M"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="arModel"></param>
        /// <returns></returns>
        public static List<T> CreateDTOList<M, T>(IList<M> arModel) where T : new()
        {
            if (arModel == null) return null;
            List<T> arDTO = new List<T>(arModel.Count);
            foreach (M model in arModel)
            {
                arDTO.Add(AutoMapper.CreateDTO<M, T>(model));
            }
            return arDTO;
        }

        /// <summary>
        /// Dung khi tao moi
        /// </summary>
        /// <typeparam name="M"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static M CreateModel<M, T>(T dto) where M : new()
        {
            if (dto == null) return default(M);
            M model = new M();
            foreach (var pro in dto.GetType().GetProperties())
            {
                string memberName = pro.Name;
                // bo qua truong Id ko update tu DTO
                if (memberName == "Id") continue;
                var modelProperty = model.GetType().GetProperty(memberName);
                if (modelProperty == null) continue;
                modelProperty.SetValue(model, pro.GetValue(dto));
            }
            return model;
        }
    }
    
}