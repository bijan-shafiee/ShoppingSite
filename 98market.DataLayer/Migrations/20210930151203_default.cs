using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _98market.DataLayer.Migrations
{
    public partial class @default : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brands",
                columns: table => new
                {
                    brandid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brandname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brands", x => x.brandid);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Categoryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryFaTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryEnTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SubCategory = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Slider = table.Column<int>(type: "int", nullable: false),
                    SliderCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Categoryid);
                    table.ForeignKey(
                        name: "FK_categories_categories_SubCategory",
                        column: x => x.SubCategory,
                        principalTable: "categories",
                        principalColumn: "Categoryid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "discounts",
                columns: table => new
                {
                    discountid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    discountcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discountpersent = table.Column<int>(type: "int", nullable: false),
                    Useablecount = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discounts", x => x.discountid);
                });

            migrationBuilder.CreateTable(
                name: "IndexImages",
                columns: table => new
                {
                    IndexImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image12 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link12 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndexImages", x => x.IndexImageId);
                });

            migrationBuilder.CreateTable(
                name: "mainSliders",
                columns: table => new
                {
                    Sliderid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SliderTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SliderAlt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SliderSort = table.Column<int>(type: "int", nullable: false),
                    SliderLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SliderImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mainSliders", x => x.Sliderid);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    permissionid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    permissionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissions", x => x.permissionid);
                });

            migrationBuilder.CreateTable(
                name: "ProductColors",
                columns: table => new
                {
                    colorid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    colorname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColors", x => x.colorid);
                });

            migrationBuilder.CreateTable(
                name: "productGurantees",
                columns: table => new
                {
                    GuranteeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guranteename = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productGurantees", x => x.GuranteeId);
                });

            migrationBuilder.CreateTable(
                name: "propertyNames",
                columns: table => new
                {
                    PropertyNameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_propertyNames", x => x.PropertyNameId);
                });

            migrationBuilder.CreateTable(
                name: "provinces",
                columns: table => new
                {
                    provinceid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    provincename = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provinces", x => x.provinceid);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    roleid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roltitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.roleid);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userfamily = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAccount = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userid);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    productid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productFaTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    productEnTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProductSell = table.Column<int>(type: "int", nullable: false),
                    producStart = table.Column<byte>(type: "tinyint", nullable: false),
                    Productimage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    productweith = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsOrginal = table.Column<bool>(type: "bit", nullable: false),
                    Categoryid = table.Column<int>(type: "int", nullable: false),
                    brandid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.productid);
                    table.ForeignKey(
                        name: "FK_products_brands_brandid",
                        column: x => x.brandid,
                        principalTable: "brands",
                        principalColumn: "brandid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_products_categories_Categoryid",
                        column: x => x.Categoryid,
                        principalTable: "categories",
                        principalColumn: "Categoryid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "propertyname_Categories",
                columns: table => new
                {
                    pcId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyNameId = table.Column<int>(type: "int", nullable: false),
                    Categoryid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_propertyname_Categories", x => x.pcId);
                    table.ForeignKey(
                        name: "FK_propertyname_Categories_categories_Categoryid",
                        column: x => x.Categoryid,
                        principalTable: "categories",
                        principalColumn: "Categoryid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_propertyname_Categories_propertyNames_PropertyNameId",
                        column: x => x.PropertyNameId,
                        principalTable: "propertyNames",
                        principalColumn: "PropertyNameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    cityid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cityname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    isdelete = table.Column<bool>(type: "bit", nullable: false),
                    provinceid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.cityid);
                    table.ForeignKey(
                        name: "FK_cities_provinces_provinceid",
                        column: x => x.provinceid,
                        principalTable: "provinces",
                        principalColumn: "provinceid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RolPermissionid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Roleid = table.Column<int>(type: "int", nullable: false),
                    Permissionid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.RolPermissionid);
                    table.ForeignKey(
                        name: "FK_RolePermissions_permissions_Permissionid",
                        column: x => x.Permissionid,
                        principalTable: "permissions",
                        principalColumn: "permissionid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePermissions_roles_Roleid",
                        column: x => x.Roleid,
                        principalTable: "roles",
                        principalColumn: "roleid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cart",
                columns: table => new
                {
                    cartid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: false),
                    ispay = table.Column<bool>(type: "bit", nullable: false),
                    RefId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    posted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cart", x => x.cartid);
                    table.ForeignKey(
                        name: "FK_cart_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserDiscounts",
                columns: table => new
                {
                    userdiscountid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: false),
                    Discountid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDiscounts", x => x.userdiscountid);
                    table.ForeignKey(
                        name: "FK_UserDiscounts_discounts_Discountid",
                        column: x => x.Discountid,
                        principalTable: "discounts",
                        principalColumn: "discountid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDiscounts_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    userRoleid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: false),
                    Roleid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.userRoleid);
                    table.ForeignKey(
                        name: "FK_UserRoles_roles_Roleid",
                        column: x => x.Roleid,
                        principalTable: "roles",
                        principalColumn: "roleid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    commentid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    commentTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    commnetDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Star = table.Column<int>(type: "int", nullable: false),
                    commentlike = table.Column<int>(type: "int", nullable: false),
                    commentDislike = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    recommend = table.Column<byte>(type: "tinyint", nullable: false),
                    productid = table.Column<int>(type: "int", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.commentid);
                    table.ForeignKey(
                        name: "FK_comments_products_productid",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "productid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_comments_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Faviorates",
                columns: table => new
                {
                    Faviorateid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: false),
                    productid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faviorates", x => x.Faviorateid);
                    table.ForeignKey(
                        name: "FK_Faviorates_products_productid",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "productid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Faviorates_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductGalleries",
                columns: table => new
                {
                    galleryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imagename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGalleries", x => x.galleryid);
                    table.ForeignKey(
                        name: "FK_ProductGalleries_products_productid",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "productid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductPrices",
                columns: table => new
                {
                    Productpriceid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mainprice = table.Column<int>(type: "int", nullable: false),
                    sepcialprice = table.Column<int>(type: "int", nullable: true),
                    count = table.Column<int>(type: "int", nullable: false),
                    MaxorderCount = table.Column<int>(type: "int", nullable: false),
                    productcolorid = table.Column<int>(type: "int", nullable: false),
                    productguranteeid = table.Column<int>(type: "int", nullable: false),
                    productid = table.Column<int>(type: "int", nullable: false),
                    Createdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateDisCount = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPrices", x => x.Productpriceid);
                    table.ForeignKey(
                        name: "FK_ProductPrices_ProductColors_productcolorid",
                        column: x => x.productcolorid,
                        principalTable: "ProductColors",
                        principalColumn: "colorid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductPrices_productGurantees_productguranteeid",
                        column: x => x.productguranteeid,
                        principalTable: "productGurantees",
                        principalColumn: "GuranteeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductPrices_products_productid",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "productid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductReatings",
                columns: table => new
                {
                    Reatingid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productid = table.Column<int>(type: "int", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: false),
                    propnameid = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReatings", x => x.Reatingid);
                    table.ForeignKey(
                        name: "FK_ProductReatings_products_productid",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "productid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductReatings_propertyNames_propnameid",
                        column: x => x.propnameid,
                        principalTable: "propertyNames",
                        principalColumn: "PropertyNameId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductReatings_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "propertyValues",
                columns: table => new
                {
                    PropertyValueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    propertyvalue = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    propertynameid = table.Column<int>(type: "int", nullable: false),
                    productid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_propertyValues", x => x.PropertyValueId);
                    table.ForeignKey(
                        name: "FK_propertyValues_products_productid",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "productid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_propertyValues_propertyNames_propertynameid",
                        column: x => x.propertynameid,
                        principalTable: "propertyNames",
                        principalColumn: "PropertyNameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    questionid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    questionDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: false),
                    productid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.questionid);
                    table.ForeignKey(
                        name: "FK_questions_products_productid",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "productid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_questions_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    reviewid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reviewDescription = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true),
                    Reviewnegative = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ReviewPositive = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    AticleTitle = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true),
                    ArticleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.reviewid);
                    table.ForeignKey(
                        name: "FK_reviews_products_productid",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "productid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "useraddresses",
                columns: table => new
                {
                    addresid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Recipientname = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Landlinephonenumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Plaque = table.Column<int>(type: "int", nullable: false),
                    unit = table.Column<int>(type: "int", nullable: false),
                    postalCode = table.Column<int>(type: "int", nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Isdelete = table.Column<bool>(type: "bit", nullable: false),
                    provinceid = table.Column<int>(type: "int", nullable: false),
                    cityid = table.Column<int>(type: "int", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_useraddresses", x => x.addresid);
                    table.ForeignKey(
                        name: "FK_useraddresses_cities_cityid",
                        column: x => x.cityid,
                        principalTable: "cities",
                        principalColumn: "cityid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_useraddresses_provinces_provinceid",
                        column: x => x.provinceid,
                        principalTable: "provinces",
                        principalColumn: "provinceid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_useraddresses_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartDetail",
                columns: table => new
                {
                    CartDetailid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productid = table.Column<int>(type: "int", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cartid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDetail", x => x.CartDetailid);
                    table.ForeignKey(
                        name: "FK_CartDetail_cart_Cartid",
                        column: x => x.Cartid,
                        principalTable: "cart",
                        principalColumn: "cartid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "answers",
                columns: table => new
                {
                    Answerid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    questionid = table.Column<int>(type: "int", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_answers", x => x.Answerid);
                    table.ForeignKey(
                        name: "FK_answers_questions_questionid",
                        column: x => x.questionid,
                        principalTable: "questions",
                        principalColumn: "questionid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_answers_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_answers_questionid",
                table: "answers",
                column: "questionid");

            migrationBuilder.CreateIndex(
                name: "IX_answers_userid",
                table: "answers",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_cart_userid",
                table: "cart",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_Cartid",
                table: "CartDetail",
                column: "Cartid");

            migrationBuilder.CreateIndex(
                name: "IX_categories_SubCategory",
                table: "categories",
                column: "SubCategory");

            migrationBuilder.CreateIndex(
                name: "IX_cities_provinceid",
                table: "cities",
                column: "provinceid");

            migrationBuilder.CreateIndex(
                name: "IX_comments_productid",
                table: "comments",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_comments_userid",
                table: "comments",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Faviorates_productid",
                table: "Faviorates",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_Faviorates_userid",
                table: "Faviorates",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGalleries_productid",
                table: "ProductGalleries",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_productcolorid",
                table: "ProductPrices",
                column: "productcolorid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_productguranteeid",
                table: "ProductPrices",
                column: "productguranteeid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_productid",
                table: "ProductPrices",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReatings_productid",
                table: "ProductReatings",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReatings_propnameid",
                table: "ProductReatings",
                column: "propnameid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReatings_userid",
                table: "ProductReatings",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_products_brandid",
                table: "products",
                column: "brandid");

            migrationBuilder.CreateIndex(
                name: "IX_products_Categoryid",
                table: "products",
                column: "Categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_propertyname_Categories_Categoryid",
                table: "propertyname_Categories",
                column: "Categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_propertyname_Categories_PropertyNameId",
                table: "propertyname_Categories",
                column: "PropertyNameId");

            migrationBuilder.CreateIndex(
                name: "IX_propertyValues_productid",
                table: "propertyValues",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_propertyValues_propertynameid",
                table: "propertyValues",
                column: "propertynameid");

            migrationBuilder.CreateIndex(
                name: "IX_questions_productid",
                table: "questions",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_questions_userid",
                table: "questions",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_productid",
                table: "reviews",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_Permissionid",
                table: "RolePermissions",
                column: "Permissionid");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_Roleid",
                table: "RolePermissions",
                column: "Roleid");

            migrationBuilder.CreateIndex(
                name: "IX_useraddresses_cityid",
                table: "useraddresses",
                column: "cityid");

            migrationBuilder.CreateIndex(
                name: "IX_useraddresses_provinceid",
                table: "useraddresses",
                column: "provinceid");

            migrationBuilder.CreateIndex(
                name: "IX_useraddresses_userid",
                table: "useraddresses",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiscounts_Discountid",
                table: "UserDiscounts",
                column: "Discountid");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiscounts_userid",
                table: "UserDiscounts",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_Roleid",
                table: "UserRoles",
                column: "Roleid");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_userid",
                table: "UserRoles",
                column: "userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "answers");

            migrationBuilder.DropTable(
                name: "CartDetail");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "Faviorates");

            migrationBuilder.DropTable(
                name: "IndexImages");

            migrationBuilder.DropTable(
                name: "mainSliders");

            migrationBuilder.DropTable(
                name: "ProductGalleries");

            migrationBuilder.DropTable(
                name: "ProductPrices");

            migrationBuilder.DropTable(
                name: "ProductReatings");

            migrationBuilder.DropTable(
                name: "propertyname_Categories");

            migrationBuilder.DropTable(
                name: "propertyValues");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "useraddresses");

            migrationBuilder.DropTable(
                name: "UserDiscounts");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DropTable(
                name: "cart");

            migrationBuilder.DropTable(
                name: "ProductColors");

            migrationBuilder.DropTable(
                name: "productGurantees");

            migrationBuilder.DropTable(
                name: "propertyNames");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "discounts");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "provinces");

            migrationBuilder.DropTable(
                name: "brands");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
