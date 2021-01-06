using System;
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    PrimaryContactNumber = table.Column<int>(type: "int", maxLength: 7, nullable: false),
                    SecondaryContactNumber = table.Column<int>(type: "int", maxLength: 7, nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    GenericName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    AtollId = table.Column<int>(type: "int", nullable: false)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    HospitalNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Identification = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    PrimaryContactNumber = table.Column<int>(type: "int", maxLength: 7, nullable: false),
                    SecondaryContactNumber = table.Column<int>(type: "int", nullable: true),
                    IslandId = table.Column<int>(type: "int", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseId = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    RegisteredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CancerTreatment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Medical = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surgical = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Familial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Other = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diagnosis = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: true),
                    NextFollowupDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CaseId = table.Column<int>(type: "int", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Details = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    CaseId = table.Column<int>(type: "int", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FDAB = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: true),
                    RequestedBy = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    RequestedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecievedBy = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    RecievedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DispatchedBy = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    DispatchedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AmountRemaining = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    MedicineId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    CaseId = table.Column<int>(type: "int", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "H.A.", "Haa Alif" },
                    { 18, "G.Dh.", "Gaafu Dhaalu" },
                    { 17, "G.A.", "Gaafu Alif" },
                    { 16, "L.", "Laamu" },
                    { 15, "Th.", "Thaa" },
                    { 14, "Dh.", "Dhaalu" },
                    { 13, "F.", "Faafu" },
                    { 12, "M.", "Meemu" },
                    { 11, "V.", "Vaavu" },
                    { 10, "A.Dh.", "South Ari" },
                    { 9, "A.A.", "North Ari" },
                    { 8, "K.", "Kaafu" },
                    { 7, "Lh.", "Lhaviyani" },
                    { 6, "B.", "Baa" },
                    { 5, "R.", "Raa" },
                    { 4, "N.", "Noonu" },
                    { 3, "Sh.", "Shaviyani" },
                    { 2, "H.Dh.", "Haa Dhaalu" },
                    { 19, "Gn.", "Gnaviyani" },
                    { 20, "S.", "Seenu" }
                });

            migrationBuilder.InsertData(
                table: "Islands",
                columns: new[] { "Id", "AtollId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Baarah" },
                    { 123, 11, "Thinadhoo" },
                    { 124, 12, "Boli Mulah" },
                    { 125, 12, "Dhiggaru" },
                    { 126, 12, "Kolhufushi" },
                    { 127, 12, "Madifushi" },
                    { 128, 12, "Maduvvaree" },
                    { 129, 12, "Muli " },
                    { 130, 12, "Naalaafushi" },
                    { 131, 12, "Raimmandhoo" },
                    { 122, 11, "Rakeedhoo" },
                    { 132, 12, "Veyvah" },
                    { 134, 13, "Dharanboodhoo" },
                    { 135, 13, "Feeali" },
                    { 136, 13, "Magoodhoo" },
                    { 137, 13, "Nilandhoo" },
                    { 138, 14, "Bandidhoo" },
                    { 139, 14, "Gemendhoo" },
                    { 140, 14, "Hulhudheli" },
                    { 141, 14, "Kudahuvadhoo " },
                    { 142, 14, "Maaenboodhoo" },
                    { 133, 13, "Bileddhoo" },
                    { 143, 14, "Meedhoo" },
                    { 121, 11, "Keyodhoo" },
                    { 119, 11, "Felidhoo " },
                    { 99, 8, "Vilimalé " },
                    { 100, 9, "Bodufolhudhoo" },
                    { 101, 9, "Feridhoo" },
                    { 102, 9, "Himandhoo" },
                    { 103, 9, "Maalhos" },
                    { 104, 9, "Mathiveri" },
                    { 105, 9, "Rasdhoo" },
                    { 106, 9, "Thoddoo" },
                    { 107, 9, "Ukulhas" },
                    { 120, 11, "Fulidhoo" },
                    { 108, 9, "Fesdhoo" },
                    { 110, 10, "Dhiddhoo" },
                    { 111, 10, "Dhigurah" },
                    { 112, 10, "Fenfushi" },
                    { 113, 10, "Haggnaameedhoo" },
                    { 114, 10, "Kunburudhoo" },
                    { 115, 10, "Maamingili" }
                });

            migrationBuilder.InsertData(
                table: "Islands",
                columns: new[] { "Id", "AtollId", "Name" },
                values: new object[,]
                {
                    { 116, 10, "Mahibadhoo " },
                    { 117, 10, "Mandhoo" },
                    { 118, 10, "Omadhoo" },
                    { 109, 10, "Dhangethi" },
                    { 144, 14, "Rinbudhoo" },
                    { 145, 14, "Vaanee" },
                    { 146, 15, "Burunee" },
                    { 172, 17, "Kanduhulhudhoo" },
                    { 173, 17, "Kolamaafushi" },
                    { 174, 17, "Kondey" },
                    { 175, 17, "Maamendhoo" },
                    { 176, 17, "Nilandhoo" },
                    { 177, 17, "Villingili" },
                    { 178, 18, "Fares-Maathodaa" },
                    { 179, 18, "Fiyoaree" },
                    { 180, 18, "Gaddhoo" },
                    { 171, 17, "Gemanafushi" },
                    { 181, 18, "Hoandeddhoo" },
                    { 183, 18, "Nadellaa" },
                    { 184, 18, "Rathafandhoo" },
                    { 185, 18, "Thinadhoo " },
                    { 186, 18, "Vaadhoo" },
                    { 187, 19, "Fuvahmulah" },
                    { 188, 20, "Hithadhoo " },
                    { 189, 20, "Maradhoo" },
                    { 190, 20, "Maradhoo-Feydhoo " },
                    { 191, 20, "Feydhoo" },
                    { 182, 18, "Madaveli" },
                    { 170, 17, "Dhevvadhoo" },
                    { 169, 17, "Dhaandhoo" },
                    { 168, 16, "Mundoo" },
                    { 147, 15, "Vilufushi" },
                    { 148, 15, "Madifushi" },
                    { 149, 15, "Dhiyamingili" },
                    { 150, 15, "Guraidhoo" },
                    { 151, 15, "Gaadhiffushi" },
                    { 152, 15, "Thimarafushi" },
                    { 153, 15, "Veymandoo " },
                    { 154, 15, "Kinbidhoo" },
                    { 155, 15, "Omadhoo" },
                    { 156, 15, "Hirilandhoo" },
                    { 157, 15, "Kandoodhoo" }
                });

            migrationBuilder.InsertData(
                table: "Islands",
                columns: new[] { "Id", "AtollId", "Name" },
                values: new object[,]
                {
                    { 158, 15, "Vandhoo" },
                    { 159, 16, "Dhanbidhoo" },
                    { 160, 16, "Fonadhoo " },
                    { 161, 16, "Gan" },
                    { 162, 16, "Hithadhoo" },
                    { 163, 16, "Isdhoo" },
                    { 164, 16, "Kunahandhoo" },
                    { 165, 16, "Maabaidhoo" },
                    { 166, 16, "Maamendhoo" },
                    { 167, 16, "Maavah" },
                    { 98, 8, "Thulusdhoo " },
                    { 192, 20, "Hulhudhoo" },
                    { 97, 8, "Maafushi " },
                    { 95, 8, "Kaashidhoo" },
                    { 26, 2, "Makunudhoo" },
                    { 27, 2, "Hirimaradhoo" },
                    { 28, 3, "Bileffahi" },
                    { 29, 3, "Feevah" },
                    { 30, 3, "Feydhoo" },
                    { 31, 3, "Foakaidhoo" },
                    { 32, 3, "Funadhoo" },
                    { 33, 3, "Goidhoo" },
                    { 34, 3, "Kanditheemu" },
                    { 25, 2, "Vaikaradhoo" },
                    { 35, 3, "Komandoo" },
                    { 37, 3, "Maaungoodhoo" },
                    { 38, 3, "Maroshi" },
                    { 39, 3, "Milandhoo" },
                    { 40, 3, "Narudhoo" },
                    { 41, 3, "Noomaraa" },
                    { 42, 4, "Foddhoo" },
                    { 43, 4, "Henbandhoo" },
                    { 44, 4, "Holhudhoo" },
                    { 45, 4, "Kendhikulhudhoo" },
                    { 36, 3, "Lhaimagu" },
                    { 46, 4, "Kudafari" },
                    { 24, 2, "Neykurdnedhoo" },
                    { 22, 2, "Kulhudhuffushi" },
                    { 2, 1, "Dhiddhoo" },
                    { 3, 1, "Filladhoo" },
                    { 4, 1, "Hoarafushi" },
                    { 5, 1, "Ihavandhoo" }
                });

            migrationBuilder.InsertData(
                table: "Islands",
                columns: new[] { "Id", "AtollId", "Name" },
                values: new object[,]
                {
                    { 6, 1, "Kelaa" },
                    { 7, 1, "Maarandhoo" },
                    { 8, 1, "Mulhadhoo" },
                    { 9, 1, "Muraidhoo" },
                    { 10, 1, "Thakandhoo" },
                    { 23, 2, "Kumundhoo" },
                    { 11, 1, "Thuraakunu" },
                    { 13, 1, "Utheemu" },
                    { 14, 1, "Vashafaru" },
                    { 15, 2, "Hanimaadhoo" },
                    { 16, 2, "Finey" },
                    { 17, 2, "Naivadhoo" },
                    { 18, 2, "Nolhivaranfaru" },
                    { 19, 2, "Nellaidhoo" },
                    { 20, 2, "Nolhivaram" },
                    { 21, 2, "Kurinbi" },
                    { 12, 1, "Uligamu" },
                    { 47, 4, "Landhoo" },
                    { 48, 4, "Lhohi" },
                    { 49, 4, "Maafaru" },
                    { 75, 6, "Goidhoo" },
                    { 76, 6, "Hithaadhoo" },
                    { 77, 6, "Kamadhoo" },
                    { 78, 6, "Kendhoo" },
                    { 79, 6, "Kihaadhoo" },
                    { 80, 6, "Kudarikilu" },
                    { 81, 6, "Maalhos" },
                    { 82, 6, "Thulhaadhoo" },
                    { 83, 7, "Hinnavaru" },
                    { 74, 6, "Fulhadhoo" },
                    { 84, 7, "Kurendhoo" },
                    { 86, 7, "Naifaru " },
                    { 87, 7, "Olhuvelifushi" },
                    { 88, 8, "Dhiffushi" },
                    { 89, 8, "Gaafaru" },
                    { 90, 8, "Gulhi" },
                    { 91, 8, "Guraidhoo" },
                    { 92, 8, "Himmafushi" },
                    { 93, 8, "Hulhumalé" },
                    { 94, 8, "Huraa" },
                    { 85, 7, "Maafilaafushi" },
                    { 73, 6, "Fehendhoo" }
                });

            migrationBuilder.InsertData(
                table: "Islands",
                columns: new[] { "Id", "AtollId", "Name" },
                values: new object[,]
                {
                    { 72, 6, "Eydhafushi " },
                    { 71, 6, "Dhonfanu" },
                    { 50, 4, "Maalhendhoo" },
                    { 51, 4, "Magoodhoo" },
                    { 52, 4, "Manadhoo " },
                    { 53, 4, "Miladhoo" },
                    { 54, 4, "Velidhoo" },
                    { 55, 5, "Alifushi" },
                    { 56, 5, "Angolhitheemu" },
                    { 57, 5, "Fainu" },
                    { 58, 5, "Hulhudhuffaaru" },
                    { 59, 5, "Inguraidhoo" },
                    { 60, 5, "Innamaadhoo" },
                    { 61, 5, "Dhuvaafaru" },
                    { 62, 5, "Kinolhas" },
                    { 63, 5, "Maakurathu" },
                    { 64, 5, "Maduvvaree" },
                    { 65, 5, "Meedhoo" },
                    { 66, 5, "Rasgetheemu" },
                    { 67, 5, "Rasmaadhoo" },
                    { 68, 5, "Ungoofaaru" },
                    { 69, 5, "Vaadhoo" },
                    { 70, 6, "Dharavandhoo" },
                    { 96, 8, "Malé " },
                    { 193, 20, "Meedhoo" }
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
                unique: true,
                filter: "[HospitalNumber] IS NOT NULL");

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
                unique: true,
                filter: "[RegistrationNumber] IS NOT NULL");
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
