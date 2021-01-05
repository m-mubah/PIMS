using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PIMS.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(60) CHARACTER SET utf8mb4", maxLength: 60, nullable: false),
                    Code = table.Column<string>(type: "varchar(5) CHARACTER SET utf8mb4", maxLength: 5, nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atolls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Case_Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(120) CHARACTER SET utf8mb4", maxLength: 120, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Case_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicine_Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(120) CHARACTER SET utf8mb4", maxLength: 120, nullable: false),
                    PrimaryContactNumber = table.Column<int>(type: "int", maxLength: 7, nullable: false),
                    SecondaryContactNumber = table.Column<int>(type: "int", maxLength: 7, nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine_Vendors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(120) CHARACTER SET utf8mb4", maxLength: 120, nullable: false),
                    GenericName = table.Column<string>(type: "varchar(120) CHARACTER SET utf8mb4", maxLength: 120, nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Test_Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(120) CHARACTER SET utf8mb4", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "varchar(240) CHARACTER SET utf8mb4", maxLength: 240, nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Islands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(160) CHARACTER SET utf8mb4", maxLength: 160, nullable: false),
                    AtollId = table.Column<int>(type: "int", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Islands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Islands_Atolls_AtollId",
                        column: x => x.AtollId,
                        principalTable: "Atolls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RegistrationNumber = table.Column<string>(type: "varchar(12) CHARACTER SET utf8mb4", maxLength: 12, nullable: true),
                    HospitalNumber = table.Column<string>(type: "varchar(12) CHARACTER SET utf8mb4", maxLength: 12, nullable: true),
                    FullName = table.Column<string>(type: "varchar(120) CHARACTER SET utf8mb4", maxLength: 120, nullable: false),
                    Identification = table.Column<string>(type: "varchar(12) CHARACTER SET utf8mb4", maxLength: 12, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    PrimaryContactNumber = table.Column<int>(type: "int", maxLength: 7, nullable: false),
                    SecondaryContactNumber = table.Column<int>(type: "int", nullable: true),
                    IslandId = table.Column<int>(type: "int", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Islands_IslandId",
                        column: x => x.IslandId,
                        principalTable: "Islands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CaseId = table.Column<string>(type: "varchar(7) CHARACTER SET utf8mb4", maxLength: 7, nullable: false),
                    Diagnosis = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Remarks = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    RegisteredDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cases_Case_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Case_Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cases_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patient_Histories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CancerTreatment = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Medical = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Surgical = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Familial = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Other = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient_Histories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Histories_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Case_Followups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Diagnosis = table.Column<string>(type: "varchar(240) CHARACTER SET utf8mb4", maxLength: 240, nullable: false),
                    Remarks = table.Column<string>(type: "varchar(240) CHARACTER SET utf8mb4", maxLength: 240, nullable: true),
                    NextFollowupDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CaseId = table.Column<int>(type: "int", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Case_Followups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Case_Followups_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Case_Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Details = table.Column<string>(type: "varchar(240) CHARACTER SET utf8mb4", maxLength: 240, nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    CaseId = table.Column<int>(type: "int", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Case_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Case_Tests_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Case_Tests_Test_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Test_Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicine_Requisitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FDAB = table.Column<string>(type: "varchar(240) CHARACTER SET utf8mb4", maxLength: 240, nullable: true),
                    RequestedBy = table.Column<string>(type: "varchar(120) CHARACTER SET utf8mb4", maxLength: 120, nullable: false),
                    RequestedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RecievedBy = table.Column<string>(type: "varchar(120) CHARACTER SET utf8mb4", maxLength: 120, nullable: true),
                    RecievedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DispatchedBy = table.Column<string>(type: "varchar(120) CHARACTER SET utf8mb4", maxLength: 120, nullable: true),
                    DispatchedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AmountRemaining = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Remarks = table.Column<string>(type: "varchar(240) CHARACTER SET utf8mb4", maxLength: 240, nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    MedicineId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    CaseId = table.Column<int>(type: "int", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine_Requisitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicine_Requisitions_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicine_Requisitions_Medicine_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Medicine_Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicine_Requisitions_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Atolls",
                columns: new[] { "Id", "Code", "DeletedOn", "Name" },
                values: new object[,]
                {
                    { 1, "H.A.", null, "Haa Alif" },
                    { 18, "G.Dh.", null, "Gaafu Dhaalu" },
                    { 17, "G.A.", null, "Gaafu Alif" },
                    { 16, "L.", null, "Laamu" },
                    { 15, "Th.", null, "Thaa" },
                    { 14, "Dh.", null, "Dhaalu" },
                    { 13, "F.", null, "Faafu" },
                    { 12, "M.", null, "Meemu" },
                    { 11, "V.", null, "Vaavu" },
                    { 10, "A.Dh.", null, "South Ari" },
                    { 9, "A.A.", null, "North Ari" },
                    { 8, "K.", null, "Kaafu" },
                    { 7, "Lh.", null, "Lhaviyani" },
                    { 6, "B.", null, "Baa" },
                    { 5, "R.", null, "Raa" },
                    { 4, "N.", null, "Noonu" },
                    { 3, "Sh.", null, "Shaviyani" },
                    { 2, "H.Dh.", null, "Haa Dhaalu" },
                    { 19, "Gn.", null, "Gnaviyani" },
                    { 20, "S.", null, "Seenu" }
                });

            migrationBuilder.InsertData(
                table: "Islands",
                columns: new[] { "Id", "AtollId", "DeletedOn", "Name" },
                values: new object[,]
                {
                    { 1, 1, null, "Baarah" },
                    { 123, 11, null, "Thinadhoo" },
                    { 124, 12, null, "Boli Mulah" },
                    { 125, 12, null, "Dhiggaru" },
                    { 126, 12, null, "Kolhufushi" },
                    { 127, 12, null, "Madifushi" },
                    { 128, 12, null, "Maduvvaree" },
                    { 129, 12, null, "Muli " },
                    { 130, 12, null, "Naalaafushi" },
                    { 131, 12, null, "Raimmandhoo" },
                    { 122, 11, null, "Rakeedhoo" },
                    { 132, 12, null, "Veyvah" },
                    { 134, 13, null, "Dharanboodhoo" },
                    { 135, 13, null, "Feeali" },
                    { 136, 13, null, "Magoodhoo" },
                    { 137, 13, null, "Nilandhoo" },
                    { 138, 14, null, "Bandidhoo" },
                    { 139, 14, null, "Gemendhoo" },
                    { 140, 14, null, "Hulhudheli" },
                    { 141, 14, null, "Kudahuvadhoo " },
                    { 142, 14, null, "Maaenboodhoo" },
                    { 133, 13, null, "Bileddhoo" },
                    { 143, 14, null, "Meedhoo" },
                    { 121, 11, null, "Keyodhoo" },
                    { 119, 11, null, "Felidhoo " },
                    { 99, 8, null, "Vilimalé " },
                    { 100, 9, null, "Bodufolhudhoo" },
                    { 101, 9, null, "Feridhoo" },
                    { 102, 9, null, "Himandhoo" },
                    { 103, 9, null, "Maalhos" },
                    { 104, 9, null, "Mathiveri" },
                    { 105, 9, null, "Rasdhoo" },
                    { 106, 9, null, "Thoddoo" },
                    { 107, 9, null, "Ukulhas" },
                    { 120, 11, null, "Fulidhoo" },
                    { 108, 9, null, "Fesdhoo" },
                    { 110, 10, null, "Dhiddhoo" },
                    { 111, 10, null, "Dhigurah" },
                    { 112, 10, null, "Fenfushi" },
                    { 113, 10, null, "Haggnaameedhoo" },
                    { 114, 10, null, "Kunburudhoo" },
                    { 115, 10, null, "Maamingili" },
                    { 116, 10, null, "Mahibadhoo " },
                    { 117, 10, null, "Mandhoo" },
                    { 118, 10, null, "Omadhoo" },
                    { 109, 10, null, "Dhangethi" },
                    { 144, 14, null, "Rinbudhoo" },
                    { 145, 14, null, "Vaanee" },
                    { 146, 15, null, "Burunee" },
                    { 172, 17, null, "Kanduhulhudhoo" },
                    { 173, 17, null, "Kolamaafushi" },
                    { 174, 17, null, "Kondey" },
                    { 175, 17, null, "Maamendhoo" },
                    { 176, 17, null, "Nilandhoo" },
                    { 177, 17, null, "Villingili" },
                    { 178, 18, null, "Fares-Maathodaa" },
                    { 179, 18, null, "Fiyoaree" },
                    { 180, 18, null, "Gaddhoo" },
                    { 171, 17, null, "Gemanafushi" },
                    { 181, 18, null, "Hoandeddhoo" },
                    { 183, 18, null, "Nadellaa" },
                    { 184, 18, null, "Rathafandhoo" },
                    { 185, 18, null, "Thinadhoo " },
                    { 186, 18, null, "Vaadhoo" },
                    { 187, 19, null, "Fuvahmulah" },
                    { 188, 20, null, "Hithadhoo " },
                    { 189, 20, null, "Maradhoo" },
                    { 190, 20, null, "Maradhoo-Feydhoo " },
                    { 191, 20, null, "Feydhoo" },
                    { 182, 18, null, "Madaveli" },
                    { 170, 17, null, "Dhevvadhoo" },
                    { 169, 17, null, "Dhaandhoo" },
                    { 168, 16, null, "Mundoo" },
                    { 147, 15, null, "Vilufushi" },
                    { 148, 15, null, "Madifushi" },
                    { 149, 15, null, "Dhiyamingili" },
                    { 150, 15, null, "Guraidhoo" },
                    { 151, 15, null, "Gaadhiffushi" },
                    { 152, 15, null, "Thimarafushi" },
                    { 153, 15, null, "Veymandoo " },
                    { 154, 15, null, "Kinbidhoo" },
                    { 155, 15, null, "Omadhoo" },
                    { 156, 15, null, "Hirilandhoo" },
                    { 157, 15, null, "Kandoodhoo" },
                    { 158, 15, null, "Vandhoo" },
                    { 159, 16, null, "Dhanbidhoo" },
                    { 160, 16, null, "Fonadhoo " },
                    { 161, 16, null, "Gan" },
                    { 162, 16, null, "Hithadhoo" },
                    { 163, 16, null, "Isdhoo" },
                    { 164, 16, null, "Kunahandhoo" },
                    { 165, 16, null, "Maabaidhoo" },
                    { 166, 16, null, "Maamendhoo" },
                    { 167, 16, null, "Maavah" },
                    { 98, 8, null, "Thulusdhoo " },
                    { 192, 20, null, "Hulhudhoo" },
                    { 97, 8, null, "Maafushi " },
                    { 95, 8, null, "Kaashidhoo" },
                    { 26, 2, null, "Makunudhoo" },
                    { 27, 2, null, "Hirimaradhoo" },
                    { 28, 3, null, "Bileffahi" },
                    { 29, 3, null, "Feevah" },
                    { 30, 3, null, "Feydhoo" },
                    { 31, 3, null, "Foakaidhoo" },
                    { 32, 3, null, "Funadhoo" },
                    { 33, 3, null, "Goidhoo" },
                    { 34, 3, null, "Kanditheemu" },
                    { 25, 2, null, "Vaikaradhoo" },
                    { 35, 3, null, "Komandoo" },
                    { 37, 3, null, "Maaungoodhoo" },
                    { 38, 3, null, "Maroshi" },
                    { 39, 3, null, "Milandhoo" },
                    { 40, 3, null, "Narudhoo" },
                    { 41, 3, null, "Noomaraa" },
                    { 42, 4, null, "Foddhoo" },
                    { 43, 4, null, "Henbandhoo" },
                    { 44, 4, null, "Holhudhoo" },
                    { 45, 4, null, "Kendhikulhudhoo" },
                    { 36, 3, null, "Lhaimagu" },
                    { 46, 4, null, "Kudafari" },
                    { 24, 2, null, "Neykurdnedhoo" },
                    { 22, 2, null, "Kulhudhuffushi" },
                    { 2, 1, null, "Dhiddhoo" },
                    { 3, 1, null, "Filladhoo" },
                    { 4, 1, null, "Hoarafushi" },
                    { 5, 1, null, "Ihavandhoo" },
                    { 6, 1, null, "Kelaa" },
                    { 7, 1, null, "Maarandhoo" },
                    { 8, 1, null, "Mulhadhoo" },
                    { 9, 1, null, "Muraidhoo" },
                    { 10, 1, null, "Thakandhoo" },
                    { 23, 2, null, "Kumundhoo" },
                    { 11, 1, null, "Thuraakunu" },
                    { 13, 1, null, "Utheemu" },
                    { 14, 1, null, "Vashafaru" },
                    { 15, 2, null, "Hanimaadhoo" },
                    { 16, 2, null, "Finey" },
                    { 17, 2, null, "Naivadhoo" },
                    { 18, 2, null, "Nolhivaranfaru" },
                    { 19, 2, null, "Nellaidhoo" },
                    { 20, 2, null, "Nolhivaram" },
                    { 21, 2, null, "Kurinbi" },
                    { 12, 1, null, "Uligamu" },
                    { 47, 4, null, "Landhoo" },
                    { 48, 4, null, "Lhohi" },
                    { 49, 4, null, "Maafaru" },
                    { 75, 6, null, "Goidhoo" },
                    { 76, 6, null, "Hithaadhoo" },
                    { 77, 6, null, "Kamadhoo" },
                    { 78, 6, null, "Kendhoo" },
                    { 79, 6, null, "Kihaadhoo" },
                    { 80, 6, null, "Kudarikilu" },
                    { 81, 6, null, "Maalhos" },
                    { 82, 6, null, "Thulhaadhoo" },
                    { 83, 7, null, "Hinnavaru" },
                    { 74, 6, null, "Fulhadhoo" },
                    { 84, 7, null, "Kurendhoo" },
                    { 86, 7, null, "Naifaru " },
                    { 87, 7, null, "Olhuvelifushi" },
                    { 88, 8, null, "Dhiffushi" },
                    { 89, 8, null, "Gaafaru" },
                    { 90, 8, null, "Gulhi" },
                    { 91, 8, null, "Guraidhoo" },
                    { 92, 8, null, "Himmafushi" },
                    { 93, 8, null, "Hulhumalé" },
                    { 94, 8, null, "Huraa" },
                    { 85, 7, null, "Maafilaafushi" },
                    { 73, 6, null, "Fehendhoo" },
                    { 72, 6, null, "Eydhafushi " },
                    { 71, 6, null, "Dhonfanu" },
                    { 50, 4, null, "Maalhendhoo" },
                    { 51, 4, null, "Magoodhoo" },
                    { 52, 4, null, "Manadhoo " },
                    { 53, 4, null, "Miladhoo" },
                    { 54, 4, null, "Velidhoo" },
                    { 55, 5, null, "Alifushi" },
                    { 56, 5, null, "Angolhitheemu" },
                    { 57, 5, null, "Fainu" },
                    { 58, 5, null, "Hulhudhuffaaru" },
                    { 59, 5, null, "Inguraidhoo" },
                    { 60, 5, null, "Innamaadhoo" },
                    { 61, 5, null, "Dhuvaafaru" },
                    { 62, 5, null, "Kinolhas" },
                    { 63, 5, null, "Maakurathu" },
                    { 64, 5, null, "Maduvvaree" },
                    { 65, 5, null, "Meedhoo" },
                    { 66, 5, null, "Rasgetheemu" },
                    { 67, 5, null, "Rasmaadhoo" },
                    { 68, 5, null, "Ungoofaaru" },
                    { 69, 5, null, "Vaadhoo" },
                    { 70, 6, null, "Dharavandhoo" },
                    { 96, 8, null, "Malé " },
                    { 193, 20, null, "Meedhoo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atolls_Code",
                table: "Atolls",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atolls_Name",
                table: "Atolls",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Case_Followups_CaseId",
                table: "Case_Followups",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_Tests_CaseId",
                table: "Case_Tests",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_Tests_TypeId",
                table: "Case_Tests",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CaseId",
                table: "Cases",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_PatientId",
                table: "Cases",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_TypeId",
                table: "Cases",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Islands_AtollId",
                table: "Islands",
                column: "AtollId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_Requisitions_CaseId",
                table: "Medicine_Requisitions",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_Requisitions_MedicineId",
                table: "Medicine_Requisitions",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_Requisitions_VendorId",
                table: "Medicine_Requisitions",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Histories_PatientId",
                table: "Patient_Histories",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_HospitalNumber",
                table: "Patients",
                column: "HospitalNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Identification",
                table: "Patients",
                column: "Identification",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_IslandId",
                table: "Patients",
                column: "IslandId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_RegistrationNumber",
                table: "Patients",
                column: "RegistrationNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Case_Followups");

            migrationBuilder.DropTable(
                name: "Case_Tests");

            migrationBuilder.DropTable(
                name: "Medicine_Requisitions");

            migrationBuilder.DropTable(
                name: "Patient_Histories");

            migrationBuilder.DropTable(
                name: "Test_Types");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "Medicine_Vendors");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Case_Types");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Islands");

            migrationBuilder.DropTable(
                name: "Atolls");
        }
    }
}
