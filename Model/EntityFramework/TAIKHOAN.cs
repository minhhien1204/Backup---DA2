namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TAIKHOAN()
        {
            BAIDANGs = new HashSet<BAIDANG>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDTaiKhoan { get; set; }

        [StringLength(30)]

        [Required(ErrorMessage = "Bạn chưa nhập tên tài khoản")]
        [Display(Name = "Tên Tài khoản")]
        public string TenTaiKhoan { get; set; }






        [Required(ErrorMessage = "Nhập mật khẩu")]
        [Display(Name = "Mât khẩu")]
        public string MatKhau { get; set; }

        [StringLength(50)]



        [Required(ErrorMessage = "Bạn chưa nhập tên tài khoản")]
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }




        [DataType(DataType.Date)]
        [Display(Name = "Ngày sinh")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Column(TypeName = "date")]
        [Required(ErrorMessage = "Bạn chưa chọn ngày sinh")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(20)]


        [Required(ErrorMessage = "Bạn chưa nhập tên tài khoản")]
        [Display(Name = "Giới tính")]
        public string GioiTinh { get; set; }

        [StringLength(50)]



        [Required(ErrorMessage = "Bạn chưa nhập tên tài khoản")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(200)]



        [Required(ErrorMessage = "Bạn chưa nhập tên tài khoản")]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }




        [StringLength(20)]
        [Required(ErrorMessage = "Bạn chưa nhập tên tài khoản")]
        [Display(Name = "Số điện thoại")]

        [DataType(DataType.PhoneNumber)]
        public string SDT { get; set; }

        [StringLength(100)]


        [Required(ErrorMessage = "Bạn chưa nhập tên tài khoản")]
        [Display(Name = "Ảnh đại diện")]
        public string AnhDaiDien { get; set; }

        [StringLength(50)]
        public string TrangThaiNguoiDung { get; set; }

        [StringLength(1)]
        public string QuyenHan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAIDANG> BAIDANGs { get; set; }
    }
}
