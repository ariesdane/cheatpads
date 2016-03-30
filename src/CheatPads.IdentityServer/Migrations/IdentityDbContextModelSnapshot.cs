using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using CheatPads.IdentityServer.Identity;

namespace CheatPads.Identityserver.Migrations
{
    [DbContext(typeof(IdentityDbContext))]
    partial class IdentityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CheatPads.IdentityServer.Identity.AppUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime?>("BirthDate");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("DisplayName");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:Schema", "Auth");

                    b.HasAnnotation("Relational:TableName", "User");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:DiscriminatorProperty", "Discriminator");

                    b.HasAnnotation("Relational:DiscriminatorValue", "IdentityRole");

                    b.HasAnnotation("Relational:Schema", "Auth");

                    b.HasAnnotation("Relational:TableName", "Role");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:DiscriminatorProperty", "Discriminator");

                    b.HasAnnotation("Relational:DiscriminatorValue", "IdentityRoleClaim<string>");

                    b.HasAnnotation("Relational:Schema", "Auth");

                    b.HasAnnotation("Relational:TableName", "RoleClaim");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:DiscriminatorProperty", "Discriminator");

                    b.HasAnnotation("Relational:DiscriminatorValue", "IdentityUserClaim<string>");

                    b.HasAnnotation("Relational:Schema", "Auth");

                    b.HasAnnotation("Relational:TableName", "UserClaim");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:DiscriminatorProperty", "Discriminator");

                    b.HasAnnotation("Relational:DiscriminatorValue", "IdentityUserLogin<string>");

                    b.HasAnnotation("Relational:Schema", "Auth");

                    b.HasAnnotation("Relational:TableName", "UserLogin");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:DiscriminatorProperty", "Discriminator");

                    b.HasAnnotation("Relational:DiscriminatorValue", "IdentityUserRole<string>");

                    b.HasAnnotation("Relational:Schema", "Auth");

                    b.HasAnnotation("Relational:TableName", "UserRole");
                });

            modelBuilder.Entity("CheatPads.IdentityServer.Identity.AppRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNet.Identity.EntityFramework.IdentityRole");


                    b.HasAnnotation("Relational:DiscriminatorValue", "AppRole");
                });

            modelBuilder.Entity("CheatPads.IdentityServer.Identity.AppRoleClaim", b =>
                {
                    b.HasBaseType("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>");


                    b.HasAnnotation("Relational:DiscriminatorValue", "AppRoleClaim");
                });

            modelBuilder.Entity("CheatPads.IdentityServer.Identity.AppUserClaim", b =>
                {
                    b.HasBaseType("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>");


                    b.HasAnnotation("Relational:DiscriminatorValue", "AppUserClaim");
                });

            modelBuilder.Entity("CheatPads.IdentityServer.Identity.AppUserLogin", b =>
                {
                    b.HasBaseType("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>");


                    b.HasAnnotation("Relational:DiscriminatorValue", "AppUserLogin");
                });

            modelBuilder.Entity("CheatPads.IdentityServer.Identity.AppUserRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>");


                    b.HasAnnotation("Relational:DiscriminatorValue", "AppUserRole");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CheatPads.IdentityServer.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CheatPads.IdentityServer.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("CheatPads.IdentityServer.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CheatPads.IdentityServer.Identity.AppRoleClaim", b =>
                {
                });

            modelBuilder.Entity("CheatPads.IdentityServer.Identity.AppUserClaim", b =>
                {
                });

            modelBuilder.Entity("CheatPads.IdentityServer.Identity.AppUserLogin", b =>
                {
                });

            modelBuilder.Entity("CheatPads.IdentityServer.Identity.AppUserRole", b =>
                {
                });
        }
    }
}
