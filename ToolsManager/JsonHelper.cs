﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
namespace ToolsManager
{
    /// <summary>
    /// JSON帮助类
    /// </summary>
    class JsonHelper
    {
        /// <summary>
        /// 反序列化Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T parse<T>(string jsonString)
        {
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                return (T)new DataContractJsonSerializer(typeof(T)).ReadObject(ms);
            }
        }
        /// <summary>
        /// 序列化Json
        /// </summary>
        /// <param name="jsonObject"></param>
        /// <returns></returns>
        public static string stringify(object jsonObject)
        {
            using (var ms = new MemoryStream())
            {
                new DataContractJsonSerializer(jsonObject.GetType()).WriteObject(ms, jsonObject);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

    }
}
