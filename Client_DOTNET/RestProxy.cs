using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace SOA_Client
{
    //Объявление прокси-класса для работы по протоколу REST
    [ServiceContract]
    [DataContractFormat]
    public interface IRest2018
    {
        [WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, UriTemplate = "/rest/language")]
        void CreateLanguage(REST_Language language);

        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/rest/languages")]
        REST_Language[] ListLanguages();

        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/rest/language?id={id}")]
        REST_Language ReadLanguage(int id);

        [WebInvoke(Method = "PATCH", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, UriTemplate = "/rest/language?id={id}")]
        void UpdateLanguage(int id, REST_Language language);

        [WebInvoke(Method = "DELETE", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/rest/language?id={id}")]
        void DeleteLanguage(int id);
        //-----------------
        [WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, UriTemplate = "/rest/person")]
        void CreatePerson(REST_Person person);

        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/rest/people")]
        REST_Person[] ListPeople();

        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/rest/person?id={id}")]
        REST_Person ReadPerson(int id);

        [WebInvoke(Method = "PATCH", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, UriTemplate = "/rest/person?id={id}")]
        void UpdatePerson(int id, REST_Person person);

        [WebInvoke(Method = "DELETE", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/rest/person?id={id}")]
        void DeletePerson(int id);
    }

    //Объявление необходимые структур данных
    [DataContract]
    public class REST_Language
    {
        [DataMember]
        public string ID;

        [DataMember]
        public string Name;

        public REST_Language(string Name)
        {
            this.Name = Name;
        }

        public REST_Language(string ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }

        public REST_Language() { }
    }

    public class REST_Person
    {
        [DataMember]
        public string ID;

        [DataMember]
        public string Name;

        [DataMember]
        public int Age;

        [DataMember]
        public string Mail;

        [DataMember]
        public int LanguageID;

        [DataMember]
        public string Language;

        public REST_Person(string Name,int Age,string Mail,int LanguageID)
        {
            this.Name = Name;
            this.Age = Age;
            this.Mail = Mail;
            this.LanguageID = LanguageID;
        }

        public REST_Person(string ID, string Name,int Age,string Mail,int LanguageID)
        {
            this.ID = ID;
            this.Name = Name;
            this.Age = Age;
            this.Mail = Mail;
            this.LanguageID = LanguageID;
        }

        public REST_Person() { }
    }
}
