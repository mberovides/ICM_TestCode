namespace ICM.Taxes.Calculator.Extensions
{
    public static class OrderInfoExtension
    {
        public static Models.OrderInfo AddFrom(this Models.OrderInfo model, string zipCode)
        {
            model.From = new Models.GeoLocation { ZipCode = zipCode };
            return model;
        }

        public static Models.OrderInfo AddTo(this Models.OrderInfo model, string zipCode)
        {
            model.To = new Models.GeoLocation { ZipCode = zipCode };
            return model;
        }
    }
}
