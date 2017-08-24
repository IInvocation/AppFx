SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;
CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;
COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';
SET search_path = public, pg_catalog;
SET default_tablespace = '';
SET default_with_oids = false;
CREATE TABLE "IdentityRole" (
    "Id" integer NOT NULL,
    "ApplicationId" integer NOT NULL,
    "Identifier" uuid NOT NULL,
    "Name" character varying(256) NOT NULL,
    "LoweredName" character varying(256) NOT NULL,
    "Description" character varying(256)
);
ALTER TABLE "IdentityRole" OWNER TO appfx;
CREATE SEQUENCE "IdentityRole_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER TABLE "IdentityRole_Id_seq" OWNER TO appfx;
ALTER SEQUENCE "IdentityRole_Id_seq" OWNED BY "IdentityRole"."Id";
CREATE TABLE "IdentityUser" (
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
ALTER TABLE "IdentityUser" OWNER TO appfx;
CREATE TABLE "IdentityUserLogin" (
    "Id" integer NOT NULL,
    "ProviderName" character varying(255) NOT NULL,
    "ProviderKey" character varying(45) NOT NULL,
    "ProviderDisplayName" character varying(255),
    "UserId" uuid NOT NULL
);
ALTER TABLE "IdentityUserLogin" OWNER TO appfx;
CREATE SEQUENCE "IdentityUserLogin_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER TABLE "IdentityUserLogin_Id_seq" OWNER TO appfx;
ALTER SEQUENCE "IdentityUserLogin_Id_seq" OWNED BY "IdentityUserLogin"."Id";
CREATE TABLE "IdentityUserRole" (
    "Id" integer NOT NULL,
    "UserId" integer NOT NULL,
    "RoleId" integer NOT NULL
);
ALTER TABLE "IdentityUserRole" OWNER TO appfx;
CREATE SEQUENCE "IdentityUserRole_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER TABLE "IdentityUserRole_Id_seq" OWNER TO appfx;
ALTER SEQUENCE "IdentityUserRole_Id_seq" OWNED BY "IdentityUserRole"."Id";
CREATE SEQUENCE "IdentityUser_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER TABLE "IdentityUser_Id_seq" OWNER TO appfx;
ALTER SEQUENCE "IdentityUser_Id_seq" OWNED BY "IdentityUser"."Id";
CREATE TABLE "IdentityClaim" (
    "Id" integer NOT NULL,
    "UserId" integer NOT NULL,
    "Type" character varying(256) NOT NULL,
    "Value" character varying(256)
);
ALTER TABLE "IdentityClaim" OWNER TO appfx;
CREATE SEQUENCE "identityClaim_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER TABLE "IdentityClaim_Id_seq" OWNER TO appfx;
ALTER SEQUENCE "IdentityClaim_Id_seq" OWNED BY "IdentityClaim"."Id";
ALTER TABLE ONLY "IdentityRole" ALTER COLUMN "Id" SET DEFAULT nextval('"IdentityRole_Id_seq"'::regclass);
ALTER TABLE ONLY "IdentityUser" ALTER COLUMN "Id" SET DEFAULT nextval('"IdentityUser_Id_seq"'::regclass);
ALTER TABLE ONLY "IdentityUserLogin" ALTER COLUMN "Id" SET DEFAULT nextval('"IdentityUserLogin_Id_seq"'::regclass);
ALTER TABLE ONLY "IdentityUserRole" ALTER COLUMN "Id" SET DEFAULT nextval('"IdentityUserRole_Id_seq"'::regclass);
ALTER TABLE ONLY "IdentityClaim" ALTER COLUMN "Id" SET DEFAULT nextval('"IdentityClaim_Id_seq"'::regclass);
ALTER TABLE ONLY "IdentityRole"
    ADD CONSTRAINT "IdentityRole_pkey" PRIMARY KEY ("Id");
ALTER TABLE ONLY "IdentityUserLogin"
    ADD CONSTRAINT "IdentityUserLogin_pkey" PRIMARY KEY ("Id");
ALTER TABLE ONLY "IdentityUserRole"
    ADD CONSTRAINT "IdentityUserRole_pkey" PRIMARY KEY ("Id");
ALTER TABLE ONLY "IdentityUser"
    ADD CONSTRAINT "IdentityUser_pkey" PRIMARY KEY ("Id");
ALTER TABLE ONLY "IdentityUser"
    ADD CONSTRAINT "UX_Identifier" UNIQUE ("Identifier");
ALTER TABLE ONLY "IdentityClaim"
    ADD CONSTRAINT "IdentityClaim_pkey" PRIMARY KEY ("Id");
ALTER TABLE ONLY "IdentityClaim"
    ADD CONSTRAINT "FK_IdentityClaim_IdentityUser" FOREIGN KEY ("UserId") REFERENCES "IdentityUser"("Id");
ALTER TABLE ONLY "IdentityUserLogin"
    ADD CONSTRAINT "FK_IdentityUserLogin_IdentityUser" FOREIGN KEY ("UserId") REFERENCES "IdentityUser"("Identifier");
ALTER TABLE ONLY "IdentityUserRole"
    ADD CONSTRAINT "FK_IdentityUserRole_IdentityRole" FOREIGN KEY ("RoleId") REFERENCES "IdentityRole"("Id");
ALTER TABLE ONLY "IdentityUserRole"
    ADD CONSTRAINT "FK_IdentityUserRole_IdentityUser" FOREIGN KEY ("UserId") REFERENCES "IdentityUser"("Id");