[assembly: Serenity.Extensibility.ScriptRegistrar(typeof(Serene1.Northwind.DynamicScripts))]

namespace Serene1.Northwind
{
    using Entities;
    using Serenity.Data;
    using Serenity.Web;

    public static class DynamicScripts
    {
        public static IDynamicScript SupplierCountry =
            new DbLookupScript<SupplierRow>(
                name: "Northwind.SupplierCountry",
                getItems: cnn =>
                {
                    var fld = SupplierRow.Fields;
                    return cnn.List<SupplierRow>(q => q.Select(
                            fld.Country)
                        .Where(
                            new Criteria(fld.Country) != "" &
                            new Criteria(fld.Country).IsNotNull())
                        .Distinct(true));
                })
            {
                IdField = "Country",
                TextField = "Country"
            };
    }
}