using DataAccess;
using Modules;
using System.Data;

namespace Business
{
    public static class CountryService
    {
        public static Country FindCountry(int id)
        {
            if (CountriesCRUD.IsExist(id))
            {
                return CountriesCRUD.Read(id);
            }
            return null;
        }

        public static Country FindCountry(string countryName)
        {
            if (CountriesCRUD.IsExist(countryName))
            {
                return CountriesCRUD.Read(countryName);
            }
            return null;
        }

        public static bool AddNewCountry(Country country)
        {
            return CountriesCRUD.Create(country);
        }

        public static bool UpdateCountry(int id, Country country)
        {
            if (CountriesCRUD.IsExist(id))
            {
                return CountriesCRUD.Update(id, country);
            }
            return false;
        }

        public static bool DeleteCountry(int id)
        {
            if (CountriesCRUD.IsExist(id))
            {
                return CountriesCRUD.Delete(id);
            }
            return false;
        }

        public static bool IsExistCountry(int id)
        {
            return CountriesCRUD.IsExist(id);
        }

        public static bool IsExistCountry(string countryName)
        {
            return CountriesCRUD.IsExist(countryName);
        }

        public static DataTable CountryDataTable()
        {
            return CountriesCRUD.GetAll();
        }
    }
}