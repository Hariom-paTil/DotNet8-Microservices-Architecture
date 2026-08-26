namespace FrontEnd.WebPage.Utility
{
    public class SD
    {
        /// <summary>
        ///  enumeration for API types (GET, POST, PUT, DELETE)
        ///  suppose you want to call an api with
        ///  GET method then you can use this enum to specify the type of api call you want to make.
        /// its helpful to avoid hardcoding the api type in the code and also makes the code more readable.
        /// for example, if you want to call an api with GET method then you can use SD.ApiType.GET instead of "GET" string.
        /// enum : a special programming term used to define a custom data type holding a fixed group of named constants
        /// 
        /// its works predefine words so when we write it 
        /// help reduce mixmatch of words and also help to avoid typos in the code.
        /// 
        /// 
        /// 
        /// </summary>
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
