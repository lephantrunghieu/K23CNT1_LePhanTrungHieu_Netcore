namespace LpthLesson07.Models
{
    public class LpthEmployee
    {
        public int LpthId { get; set; }              // Mã nhân viên
        public string LpthName { get; set; }         // Họ tên
        public DateTime LpthBirthDay { get; set; }   // Ngày sinh
        public string LpthEmail { get; set; }        // Email
        public string LpthPhone { get; set; }        // Số điện thoại
        public decimal LpthSalary { get; set; }      // Lương
        public bool LpthStatus { get; set; }         // Trạng thái (true = đang làm việc, false = nghỉ việc)
    }
}
