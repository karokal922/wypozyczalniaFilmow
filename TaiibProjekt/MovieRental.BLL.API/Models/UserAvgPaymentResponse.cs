namespace MovieRental.BLL.API.Models
{
    public record UserAvgPaymentResponse
    {
        public string UserName { get; set; }
        public string AveragePayment { get; set; }
    } 

}
