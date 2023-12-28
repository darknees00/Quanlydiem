using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLD_BE.Migrations
{
    /// <inheritdoc />
    public partial class QLDiem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Pass = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PhanQuyen = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account_1", x => new { x.Login, x.Pass });
                });

            migrationBuilder.CreateTable(
                name: "GiaoVien",
                columns: table => new
                {
                    IDGV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenGV = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaoVien", x => x.IDGV);
                });

            migrationBuilder.CreateTable(
                name: "Khoa",
                columns: table => new
                {
                    IDK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoa", x => x.IDK);
                });

            migrationBuilder.CreateTable(
                name: "NamHoc",
                columns: table => new
                {
                    IDN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamHoc = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NamHoc", x => x.IDN);
                });

            migrationBuilder.CreateTable(
                name: "HocPhan",
                columns: table => new
                {
                    IDH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDGV = table.Column<int>(type: "int", nullable: true),
                    TenHP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoTC = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocPhan", x => x.IDH);
                    table.ForeignKey(
                        name: "FK_HocPhan_GiaoVien",
                        column: x => x.IDGV,
                        principalTable: "GiaoVien",
                        principalColumn: "IDGV");
                });

            migrationBuilder.CreateTable(
                name: "Lop",
                columns: table => new
                {
                    IDL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDK = table.Column<int>(type: "int", nullable: true),
                    TenLop = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lop", x => x.IDL);
                    table.ForeignKey(
                        name: "FK_Lop_Khoa",
                        column: x => x.IDK,
                        principalTable: "Khoa",
                        principalColumn: "IDK");
                });

            migrationBuilder.CreateTable(
                name: "SinhVien",
                columns: table => new
                {
                    IDSV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IDL = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVien", x => x.IDSV);
                    table.ForeignKey(
                        name: "FK_SinhVien_Lop",
                        column: x => x.IDL,
                        principalTable: "Lop",
                        principalColumn: "IDL");
                });

            migrationBuilder.CreateTable(
                name: "Diem",
                columns: table => new
                {
                    IDD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiemCC = table.Column<int>(type: "int", nullable: true),
                    DiemLan1 = table.Column<int>(type: "int", nullable: true),
                    DiemLan2 = table.Column<int>(type: "int", nullable: true),
                    DiemCuoiKy = table.Column<int>(type: "int", nullable: true),
                    DiemTB = table.Column<int>(type: "int", nullable: true),
                    IDSV = table.Column<int>(type: "int", nullable: true),
                    IDH = table.Column<int>(type: "int", nullable: true),
                    IDN = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diem", x => x.IDD);
                    table.ForeignKey(
                        name: "FK_Diem_HocPhan",
                        column: x => x.IDH,
                        principalTable: "HocPhan",
                        principalColumn: "IDH");
                    table.ForeignKey(
                        name: "FK_Diem_NamHoc",
                        column: x => x.IDN,
                        principalTable: "NamHoc",
                        principalColumn: "IDN");
                    table.ForeignKey(
                        name: "FK_Diem_SinhVien",
                        column: x => x.IDSV,
                        principalTable: "SinhVien",
                        principalColumn: "IDSV");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diem_IDH",
                table: "Diem",
                column: "IDH");

            migrationBuilder.CreateIndex(
                name: "IX_Diem_IDN",
                table: "Diem",
                column: "IDN");

            migrationBuilder.CreateIndex(
                name: "IX_Diem_IDSV",
                table: "Diem",
                column: "IDSV");

            migrationBuilder.CreateIndex(
                name: "IX_HocPhan_IDGV",
                table: "HocPhan",
                column: "IDGV");

            migrationBuilder.CreateIndex(
                name: "IX_Lop_IDK",
                table: "Lop",
                column: "IDK");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_IDL",
                table: "SinhVien",
                column: "IDL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Diem");

            migrationBuilder.DropTable(
                name: "HocPhan");

            migrationBuilder.DropTable(
                name: "NamHoc");

            migrationBuilder.DropTable(
                name: "SinhVien");

            migrationBuilder.DropTable(
                name: "GiaoVien");

            migrationBuilder.DropTable(
                name: "Lop");

            migrationBuilder.DropTable(
                name: "Khoa");
        }
    }
}
