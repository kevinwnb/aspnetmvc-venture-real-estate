using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace MockUp.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name is too long")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last name is too long")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        public virtual string CustFullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [Display(Name = "Middle Name")]
        [StringLength(50, ErrorMessage = "Middle name is too long")]
        public string MiddleName { get; set; }

        //Create Custom Date Range - Still not working

        [Required]
        [MinimumAge(19, ErrorMessage = "Sorry, you must be age of majority")]
        [DataType(DataType.Date)]
        [Display(Name = "DOB")]



        public DateTime BirthDay { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        [StringLength(25, ErrorMessage = "Street address is too long")]
        public string StreetAddress { get; set; }

        [Required]
        [Display(Name = "Municipality")]
        [StringLength(25, ErrorMessage = "Municipality is too long")]
        public string Municipality { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        [RegularExpression(@"^[ABCEGHJKLMNPRSTVXYabceghjklmnprstvxy]{1}\d{1}[A-Za-z]{1} *\d{1}[A-Za-z]{1}\d{1}$", ErrorMessage = "Please enter a valid Postal Code")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Postal Code must be between 5 and 10 characters long depending on country")]
        public string PostalCode { get; set; }

        [Required]
        [Display(Name = "Province:")]
        public Prov CustomerProv { get; set; }

        [Required]
        [Display(Name = "Country")]
        public CustCountry custCountry { get; set; }

        [Display(Name = "Home Phone")]
        [StringLength(15, ErrorMessage = "Phone number cannot be more than 15 characters")]
        public string HomePhone { get; set; }

        [Required]
        [Display(Name = "Cell Phone")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Phone number must be between 5 and 15 characters")]
        public string CellPhone { get; set; }

        [Required]
        [Display(Name = "Email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter a valid email address")]
        [DataType(DataType.EmailAddress)]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Email must be between 5 and 150 characters")]
        public string Email { get; set; }



        public bool isTrue => true;

        [Required]
        [Display(Name = "Have you checked proof of ID?")]
        [Compare(nameof(isTrue), ErrorMessage = "Indentity must be confrimed")]
        public bool CheckId { get; set; }

    }

    public class MinimumAgeAttribute : ValidationAttribute
    {
        public MinimumAgeAttribute(int minimumAge)
        {
            MinimumAge = minimumAge;
            ErrorMessage = "{0} must be someone at least {1} years of age";
        }

        public override bool IsValid(object value)
        {
            DateTime date;
            if ((value != null && DateTime.TryParse(value.ToString(), out date)))
            {
                return date.AddYears(MinimumAge) < DateTime.Now;
            }

            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, MinimumAge);
        }

        public int MinimumAge { get; }
    }






    public enum Prov
    {
        Alberta = 1,
        BritishColumbia = 2,
        Manitoba = 3,
        NewBrunswick = 0,
        Newfoundland = 4,
        NovaScotia = 5,
        Nunavut = 6,
        Ontario = 7,
        PrinceEdwardIsland = 8,
        Quebec = 9,
        Saskatchewan = 10,
        Yukon = 11,
        Other = 12

    }

    public enum CustCountry
    {
        Afghanistan = 1,
        Albania = 2,
        Algeria = 3,
        Andorra = 4,
        Angola = 5,
        Antigua = 6,
        Argentina = 7,
        Armenia = 8,
        Austria = 9,
        Azerbaijan = 10,
        Bahamas = 11,
        Bahrain = 12,
        Bangladesh = 13,
        Barbados = 14,
        Belarus = 15,
        Belgium = 16,
        Belize = 17,
        Benin = 18,
        Bhutan = 19,
        Bolivia = 20,
        Bosnia = 21,
        Brazil = 22,
        Brunei = 23,
        Bulgaria = 24,
        Burkina = 25,
        Burundi = 26,
        CaboVerde = 27,
        Cambodia = 28,
        Cameroon = 29,
        Canada = 0,
        CAR = 30,
        Chad = 31,
        Chile = 32,
        China = 33,
        Coloumbia = 34,
        Comoros = 35,
        Congo = 36,
        CostaRica = 37,
        CotedIvoire = 38,
        Croatia = 39,
        Cuba = 40,
        Cyprus = 41,
        Czechia = 42,
        Denmark = 43,
        Djibouti = 44,
        Dominica = 45,
        DominicanRepublic = 46,
        Ecuador = 47,
        Egypt = 48,
        ElSalvador = 49,
        EquatorialGuinea = 50,
        Eritrea = 51,
        Estonia = 52,
        Eswatini = 53,
        Ethiopia = 54,
        Fiji = 55,
        Finland = 56,
        France = 57,
        Gabon = 58,
        Gambia = 59,
        Georgia = 60,
        Germany = 61,
        Ghana = 62,
        Greece = 63,
        Grenada = 64,
        Guatemala = 65,
        Guinea = 66,
        GuineaBissau = 67,
        Guyana = 68,
        Haiti = 69,
        Honduras = 70,
        Hungary = 71,
        Iceland = 72,
        India = 73,
        Indonesia = 74,
        Iran = 75,
        Iraq = 76,
        Ireland = 77,
        Israel = 78,
        Italy = 79,
        Jamaica = 80,
        Japan = 81,
        Jordan = 82,
        Kazakhstan = 83,
        Kosovo = 84,
        Kuwait = 85,
        Kyrgyzstan = 86,
        Laos = 87,
        Lativia = 88,
        Lebanon = 89,
        Lesotho = 90,
        Liberia = 91,
        Libya = 92,
        Liechtenstein = 93,
        Lithuania = 94,
        Luxembourg = 95,
        Madagascar = 96,
        Malawi = 97,
        Malaysia = 98,
        Maldives = 99,
        Mali = 100,
        Malta = 101,
        MarshallIslands = 102,
        Mauritania = 103,
        Mauririus = 104,
        Mexico = 105,
        Micronesia = 106,
        Moldova = 107,
        Monaco = 108,
        Mongolia = 109,
        Montenegro = 110,
        Morocco = 111,
        Mozambique = 112,
        Myanmar = 113,
        Namibia = 114,
        Nauru = 115,
        Nepal = 116,
        Netherlands = 117,
        NewZealand = 118,
        Nicaragua = 119,
        Niger = 120,
        Nigeria = 121,
        NorthKorea = 122,
        NorthMacedonia = 123,
        Norway = 124,
        Oman = 125,
        Pakistan = 126,
        Palau = 127,
        Palestine = 128,
        Panama = 129,
        PapuaNewGuinea = 130,
        Paraguay = 131,
        Peru = 132,
        Philippines = 133,
        Poland = 134,
        Protugal = 135,
        Qatar = 136,
        Romania = 137,
        Russia = 138,
        Rwanda = 139,
        SaintKitts = 140,
        SaintLucia = 141,
        SaintVincent = 142,
        Samoa = 143,
        SanMarino = 144,
        SaoTome = 145,
        SaudiArabia = 146,
        Senegal = 147,
        Serbia = 148,
        Seychelles = 149,
        SierraLeone = 150,
        Singapore = 151,
        Slovakia = 152,
        Slovenia = 153,
        SolomonIslands = 154,
        Somalia = 155,
        SouthAfrica = 156,
        SouthKorea = 157,
        SouthSudan = 158,
        Spain = 159,
        SriLanka = 160,
        Sudan = 161,
        Suriname = 162,
        Sweden = 163,
        Switzerland = 164,
        Syria = 165,
        Taiwan = 166,
        Tajikstan = 167,
        Tanzania = 168,
        Thailand = 169,
        TimorLeste = 170,
        Togo = 171,
        Tonga = 172,
        Trinidad = 173,
        Tunisia = 174,
        Turkey = 175,
        Turkmenistan = 176,
        Tuvalu = 177,
        Uganda = 178,
        Ukraine = 179,
        UAE = 180,
        UK = 181,
        USA = 182,
        Uruguay = 183,
        Uzbekistan = 184,
        Vanuatu = 185,
        VaticanCity = 186,
        Venezuela = 187,
        Vietnam = 188,
        Yemen = 189,
        Zambia = 190,
        Zimbabwe = 191


    }
}