using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MVCFinalProject.Models
{
    public class Computer
    {
        public int Id { get; set; }

        private int serialNum;
        public int ManufactererSerialNumber
        {
            get
            {
                return serialNum;
            }
            set
            {
                if (value < 0) serialNum = 1000;
                else serialNum = value;
            }
        }

        private string officeNum;
        public string OfficeRoomNumber
        {
            get { return officeNum; }
            set
            {
                if (value.Length <= 40) officeNum = value;
                else throw new ConstraintException("string must be 40 or fewer characters");
            }
        }

        private string location;
        public string OfficeLocation
        {
            get
            {
                return location;
            }
            set
            {
                if (value.Length <= 40) location = value;
                else throw new ConstraintException("string must be 40 or fewer characters");
            }
        }

        private string specification;
        public string ComputerSpecification
        {
            get
            {
                return specification;
            }
            set
            {
                if (value.Length <= 15) specification = value;
                else throw new ConstraintException("string must be 15 or fewer characters");
            }
        }

        private string os;
        public string OperatingSystem
        {
            get
            {
                return os;
            }
            set
            {
                if (value.Length <= 15) os = value;
                else throw new ConstraintException("string must be 15 or fewer characters");
            }
        }

        private string owner;
        public string OwnerName
        {
            get
            {
                return owner;
            }
            set
            {
                if (value.Length <= 50) owner = value;
                else throw new ConstraintException("string must be 50 or fewer characters");
            }
        }


        [DataType(DataType.Date)]
        public DateTime InstallationDate { get; set; } = DateTime.Now;

        private decimal price;

        [DisplayFormat(DataFormatString ="{0:c}", ApplyFormatInEditMode = true)]
        public decimal Price
        {
            get { return price; }
            set
            {
                if (value > 0) price = value;
                else throw new ConstraintException("Price cannot be negative");
            }
        }
    }
}
