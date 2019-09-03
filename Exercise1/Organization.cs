namespace Exercise1
{
    public class Organization
    {

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public Organization(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
        public override string ToString()
        {
            return "Name: " + Name +"\n"+
                "PhoneNumber: " + PhoneNumber;
        }
    }
}
