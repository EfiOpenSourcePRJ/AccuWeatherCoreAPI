
using System;

namespace BusinessLogic.ErrorManagment
{
    public interface IErrorLogger
    {
        void LogError();
        void SaveErrorException(Exception ex, string URL,string additionalMessage);
    }
    public class ErrorLogger : IErrorLogger
    {
    

        public ErrorLogger()
        {
           
        }
        public void LogError()
        {
           
        }

        internal void LogError(string error)
        {

            //TO DO error save to EventViewer or other place
        }


        public void SaveErrorException(Exception ex, string URL, string additionalMessage)
        {
            //TO DO error save to DB
        }
    }
}
