SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

CREATE SCHEMA "AppFxIdentity";
ALTER SCHEMA "AppFxIdentity" OWNER TO appfx;
CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;
COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';
SET search_path = "AppFxIdentity", pg_catalog;
SET default_tablespace = '';
SET default_with_oids = false;
CREATE TABLE "Claim" (
    "Id" integer NOT NULL,
    "UserId" integer NOT NULL,
    "Type" character varying(256) NOT NULL,
    "Value" character varying(256)
);
ALTER TABLE "Claim" OWNER TO appfx;
CREATE TABLE "Role" (
    "Id" integer NOT NULL,
    "ApplicationId" integer NOT NULL,
    "Identifier" uuid NOT NULL,
    "Name" character varying(256) NOT NULL,
    "LoweredName" character varying(256) NOT NULL,
    "Description" character varying(256)
);
ALTER TABLE "Role" OWNER TO appfx;
CREATE SEQUENCE "IdentityRole_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER TABLE "IdentityRole_Id_seq" OWNER TO appfx;

ALTER SEQUENCE "IdentityRole_Id_seq" OWNED BY "Role"."Id";

CREATE TABLE "UserLogin" (
    "Id" integer NOT NULL,
    "ProviderName" character varying(255) NOT NULL,
    "ProviderKey" character varying(45) NOT NULL,
    "ProviderDisplayName" character varying(255),
    "UserId" uuid NOT NULL
);


ALTER TABLE "UserLogin" OWNER TO appfx;

CREATE SEQUENCE "IdentityUserLogin_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "IdentityUserLogin_Id_seq" OWNER TO appfx;

ALTER SEQUENCE "IdentityUserLogin_Id_seq" OWNED BY "UserLogin"."Id";

CREATE TABLE "UserRole" (
    "Id" integer NOT NULL,
    "UserId" integer NOT NULL,
    "RoleId" integer NOT NULL
);


ALTER TABLE "UserRole" OWNER TO appfx;

CREATE SEQUENCE "IdentityUserRole_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "IdentityUserRole_Id_seq" OWNER TO appfx;

ALTER SEQUENCE "IdentityUserRole_Id_seq" OWNED BY "UserRole"."Id";

CREATE TABLE "User" (
    "ApplicationId" integer NOT NULL,
    "Email" character varying(256) NOT NULL,
    "EmailConfirmed" boolean NOT NULL,
    "Id" integer NOT NULL,
    "Identifier" uuid NOT NULL,
    "IsAnonymous" boolean NOT NULL,
    "LastActivityDate" timestamp without time zone NOT NULL,
    "LoweredUserName" character varying(256) NOT NULL,
    "MobileAlias" character varying(16),
    "Name" character varying(256) NOT NULL,
    "NormalizedEmail" character varying(256),
    "PasswordHash" character varying(256),
    "Phone" character varying(256),
    "PhoneConfirmed" boolean NOT NULL,
    "SecurityStamp" character varying(256),
    "TwoFactorEnabled" boolean NOT NULL,
    "LockedOutTill" timestamp with time zone,
    "AccessFailedCount" integer NOT NULL,
    "LockoutEnabled" boolean NOT NULL
);


ALTER TABLE "User" OWNER TO appfx;

CREATE SEQUENCE "IdentityUser_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "IdentityUser_Id_seq" OWNER TO appfx;

ALTER SEQUENCE "IdentityUser_Id_seq" OWNED BY "User"."Id";

CREATE SEQUENCE "identityClaim_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "identityClaim_Id_seq" OWNER TO appfx;

ALTER SEQUENCE "identityClaim_Id_seq" OWNED BY "Claim"."Id";

SET search_path = "AppFxIdentity", pg_catalog;

ALTER TABLE ONLY "Claim" ALTER COLUMN "Id" SET DEFAULT nextval('"identityClaim_Id_seq"'::regclass);

ALTER TABLE ONLY "Role" ALTER COLUMN "Id" SET DEFAULT nextval('"IdentityRole_Id_seq"'::regclass);

ALTER TABLE ONLY "User" ALTER COLUMN "Id" SET DEFAULT nextval('"IdentityUser_Id_seq"'::regclass);

ALTER TABLE ONLY "UserLogin" ALTER COLUMN "Id" SET DEFAULT nextval('"IdentityUserLogin_Id_seq"'::regclass);

ALTER TABLE ONLY "UserRole" ALTER COLUMN "Id" SET DEFAULT nextval('"IdentityUserRole_Id_seq"'::regclass);

SET search_path = public, pg_catalog;

ALTER TABLE ONLY "Dummy" ALTER COLUMN "Id" SET DEFAULT nextval('"Dummy_Id_seq"'::regclass);

SET search_path = "AppFxIdentity", pg_catalog;

SELECT pg_catalog.setval('"IdentityRole_Id_seq"', 109, true);

SELECT pg_catalog.setval('"IdentityUserLogin_Id_seq"', 45, true);

SELECT pg_catalog.setval('"IdentityUserRole_Id_seq"', 54, true);

SELECT pg_catalog.setval('"IdentityUser_Id_seq"', 206, true);

SELECT pg_catalog.setval('"identityClaim_Id_seq"', 30, true);


SET search_path = public, pg_catalog;

SELECT pg_catalog.setval('"Dummy_Id_seq"', 77, true);

SET search_path = "AppFxIdentity", pg_catalog;

ALTER TABLE ONLY "Role"
    ADD CONSTRAINT "IdentityRole_pkey" PRIMARY KEY ("Id");

ALTER TABLE ONLY "UserLogin"
    ADD CONSTRAINT "IdentityUserLogin_pkey" PRIMARY KEY ("Id");

ALTER TABLE ONLY "UserRole"
    ADD CONSTRAINT "IdentityUserRole_pkey" PRIMARY KEY ("Id");

ALTER TABLE ONLY "User"
    ADD CONSTRAINT "IdentityUser_pkey" PRIMARY KEY ("Id");

ALTER TABLE ONLY "User"
    ADD CONSTRAINT "UX_Identifier" UNIQUE ("Identifier");

ALTER TABLE ONLY "Claim"
    ADD CONSTRAINT "identityClaim_pkey" PRIMARY KEY ("Id");


SET search_path = "AppFxIdentity", pg_catalog;

ALTER TABLE ONLY "Claim"
    ADD CONSTRAINT "FK_IdentityClaim_IdentityUser" FOREIGN KEY ("UserId") REFERENCES "User"("Id");

ALTER TABLE ONLY "UserLogin"
    ADD CONSTRAINT "FK_IdentityUserLogin_IdentityUser" FOREIGN KEY ("UserId") REFERENCES "User"("Identifier");

ALTER TABLE ONLY "UserRole"
    ADD CONSTRAINT "FK_IdentityUserRole_IdentityRole" FOREIGN KEY ("RoleId") REFERENCES "Role"("Id");

ALTER TABLE ONLY "UserRole"
    ADD CONSTRAINT "FK_IdentityUserRole_IdentityUser" FOREIGN KEY ("UserId") REFERENCES "User"("Id");
