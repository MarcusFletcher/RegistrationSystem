using System;
namespace TournamentMonitor.ViewModels
{
    public class ApiResult<T>
    {
        public T Result { get; set; }
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
    }
}