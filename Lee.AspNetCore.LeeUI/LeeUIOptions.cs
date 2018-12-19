using Newtonsoft.Json.Linq;
using Limited.AspNetCore.LeeUI;
using System;
using System.IO;
using System.Reflection;

namespace Limited.AspNetCore.LeeUI
{
    public class LeeUIOptions
    {
        public string RoutePrefix
        {
            get;
            set;
        } = "lee";


        public Func<Stream> IndexStream
        {
            get;
            set;
        } = () => typeof(LeeUIOptions).GetTypeInfo().Assembly.GetManifestResourceStream("Lee.AspNetCore.LeeUI.index.html");


        public string DocumentTitle
        {
            get;
            set;
        } = "Lee UI";


        public string HeadContent
        {
            get;
            set;
        } = "";


        public JObject ConfigObject
        {
            get;
        } = JObject.FromObject((object)new
        {
            urls = new object[0],
            validatorUrl = JValue.CreateNull()
        });


        public JObject OAuthConfigObject
        {
            get;
        } = JObject.FromObject((object)new
        {

        });

    }
}
