namespace JwtTest.Dto
{
    public class BusDto
    {
        public int BusId { get; set; }
        public int EmployeeId { get; set; }
        public int TripId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public string Number { get; set; }

        public string Location { set; get; }



    }
}
