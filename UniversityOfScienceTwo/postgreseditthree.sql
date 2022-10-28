BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory"(
	"MigrationId" TEXT NOT NULL,
	"ProductVersion" TEXT NOT NULL
);
CREATE TABLE IF NOT EXISTS "AspNetRoles"(
	"Id" TEXT NOT NULL,
	"ConcurrencyStamp" TEXT,
	"Name" TEXT,
	"NormalizedName" TEXT,
	CONSTRAINT id_unique UNIQUE ("Id")
);
CREATE TABLE IF NOT EXISTS "AspNetUserTokens"(
	"UserId" serial NOT NULL,
	"LoginProvider"	TEXT NOT NULL,
	"Name"	TEXT NOT NULL,
	"Value"	TEXT,
	PRIMARY KEY("UserId","LoginProvider","Name")
);
CREATE TABLE IF NOT EXISTS "AspNetUsers"(
	"Id" TEXT NOT NULL PRIMARY KEY,
	"AccessFailedCount"	INTEGER NOT NULL,
	"ConcurrencyStamp"	TEXT,
	"Email"	TEXT,
	"EmailConfirmed" INTEGER NOT NULL,
	"LockoutEnabled" INTEGER NOT NULL,
	"LockoutEnd" TEXT,
	"NormalizedEmail" TEXT,
	"NormalizedUserName" TEXT,
	"PasswordHash" TEXT,
	"PhoneNumber" TEXT,
	"PhoneNumberConfirmed" INTEGER NOT NULL,
	"SecurityStamp"	TEXT,
	"TwoFactorEnabled" INTEGER NOT NULL,
	"UserName"	TEXT
);
CREATE TABLE IF NOT EXISTS "AspNetRoleClaims"(
	"Id" serial PRIMARY KEY,
	"ClaimType"	TEXT,
	"ClaimValue"	TEXT,
	"RoleId"	TEXT NOT NULL,
	CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" 
		FOREIGN KEY("RoleId") 
			REFERENCES "AspNetRoles"("Id") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS "AspNetUserClaims"(
	"Id" serial PRIMARY KEY,
	"ClaimType"	TEXT,
	"ClaimValue"	TEXT,
	"UserId"	TEXT NOT NULL,
	CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" 
		FOREIGN KEY("UserId") 
			REFERENCES "AspNetUsers"("Id") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS "AspNetUserLogins"(
	"LoginProvider"	TEXT NOT NULL,
	"ProviderKey"	TEXT NOT NULL,
	"ProviderDisplayName"	TEXT,
	"UserId"	TEXT NOT NULL,
	CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY("LoginProvider","ProviderKey"),
	CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" 
		FOREIGN KEY("UserId") 
			REFERENCES "AspNetUsers"("Id") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS "AspNetUserRoles"(
	"UserId"	TEXT NOT NULL,
	"RoleId"	TEXT NOT NULL,
	CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY("UserId","RoleId"),
	CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" 
		FOREIGN KEY("RoleId") 
			REFERENCES "AspNetRoles"("Id") ON DELETE CASCADE,
	CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" 
		FOREIGN KEY("UserId") 
			REFERENCES "AspNetUsers"("Id") ON DELETE CASCADE
);
INSERT INTO "__EFMigrationsHistory" VALUES ('00000000000000_CreateIdentitySchema','1.0.2');
INSERT INTO "__EFMigrationsHistory" VALUES ('20221004193223_InitialCreate','6.0.9');
INSERT INTO "AspNetUsers" VALUES ('a197fc88-ddb4-4123-837a-3c22478473eb',0,'85235aa0-2aab-4efe-8006-be84191e649e','bennims93@gmail.com',0,1,NULL,'BENNIMS93@GMAIL.COM','BENNIMS93@GMAIL.COM','AQAAAAEAACcQAAAAEFXmOhZYk/E++ciG/uL6uWMbYY1d68xMu8Cm0qvoa3auq2bCN0DhhQAkMnooahrKiw==',NULL,0,'TSDDK4SSJ37ON4HEUKUGWDAQAS3A22IN',0,'bennims93@gmail.com');
INSERT INTO "AspNetUsers" VALUES ('d85e33da-0d8e-43df-bfc6-a1b27a04fd22',0,'dd5d18ff-b82b-4ff1-ba00-a8677a767067','email@email.com',0,1,NULL,'EMAIL@EMAIL.COM','EMAIL@EMAIL.COM','AQAAAAEAACcQAAAAEO9MRQDAT6hFufCCGns1o91k8DzfNrG0YJqlaQ7HW+db5pgD/NBaIcjunVOrtowoVQ==',NULL,0,'6IILEPSPKTA6XLP54A5YYXBIJD4VOJHV',0,'email@email.com');
INSERT INTO "AspNetUsers" VALUES ('83ef5be9-0e68-4249-b8a4-605bce2739cf',0,'e5c2af2c-0c50-4868-9fcc-b12b38fe7143','email@theemail.com',0,1,NULL,'EMAIL@THEEMAIL.COM','EMAIL@THEEMAIL.COM','AQAAAAEAACcQAAAAEK6MW7iXoKAwfnGSR2yabnXIBo+jvEYs2lmsYY/FwwhPzPu/XtlaTHEJmJYfr/cmow==',NULL,0,'PMIIBFFIK22SAYOBPVG6FTUMM2HZ6ADE',0,'email@theemail.com');
INSERT INTO "AspNetUsers" VALUES ('77024f1b-9a34-4298-8112-722c96ee2f1b',0,'091e4d77-6cbc-4504-bbdf-57cfeb632475','mynameiscards@gmail.com',0,1,NULL,'MYNAMEISCARDS@GMAIL.COM','MYNAMEISCARDS@GMAIL.COM','AQAAAAEAACcQAAAAEID+FcfB5du/177DCBuelNE5A16DLzdmILgYnvWhOMlRV5ScO08/LhomTGU4qYMwFA==',NULL,0,'ERSX67UEOFL2BKJRGRJ5J4SWJ5NZ45TL',0,'mynameiscards@gmail.com');
CREATE INDEX IF NOT EXISTS "RoleNameIndex" ON "AspNetRoles" (
	"NormalizedName"
);
CREATE INDEX IF NOT EXISTS "IX_AspNetRoleClaims_RoleId" ON "AspNetRoleClaims" (
	"RoleId"
);
CREATE INDEX IF NOT EXISTS "IX_AspNetUserClaims_UserId" ON "AspNetUserClaims" (
	"UserId"
);
CREATE INDEX IF NOT EXISTS "IX_AspNetUserLogins_UserId" ON "AspNetUserLogins" (
	"UserId"
);
CREATE INDEX IF NOT EXISTS "IX_AspNetUserRoles_RoleId" ON "AspNetUserRoles" (
	"RoleId"
);
CREATE INDEX IF NOT EXISTS "IX_AspNetUserRoles_UserId" ON "AspNetUserRoles" (
	"UserId"
);
CREATE INDEX IF NOT EXISTS "EmailIndex" ON "AspNetUsers" (
	"NormalizedEmail"
);
CREATE UNIQUE INDEX IF NOT EXISTS "UserNameIndex" ON "AspNetUsers" (
	"NormalizedUserName"
);
COMMIT;
