--
-- PostgreSQL database dump
--

-- Dumped from database version 9.6.3
-- Dumped by pg_dump version 9.6.3

-- Started on 2017-08-20 17:39:06

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 1 (class 3079 OID 12387)
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- TOC entry 2182 (class 0 OID 0)
-- Dependencies: 1
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 186 (class 1259 OID 16413)
-- Name: Dummy; Type: TABLE; Schema: public; Owner: appfx
--

CREATE TABLE "Dummy" (
    "Id" integer NOT NULL,
    "Name" character varying(256)
);


ALTER TABLE "Dummy" OWNER TO appfx;

--
-- TOC entry 185 (class 1259 OID 16411)
-- Name: Dummy_Id_seq; Type: SEQUENCE; Schema: public; Owner: appfx
--

CREATE SEQUENCE "Dummy_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "Dummy_Id_seq" OWNER TO appfx;

--
-- TOC entry 2183 (class 0 OID 0)
-- Dependencies: 185
-- Name: Dummy_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: appfx
--

ALTER SEQUENCE "Dummy_Id_seq" OWNED BY "Dummy"."Id";


--
-- TOC entry 190 (class 1259 OID 16432)
-- Name: IdentityRole; Type: TABLE; Schema: public; Owner: appfx
--

CREATE TABLE "IdentityRole" (
    "Id" integer NOT NULL,
    "ApplicationId" integer NOT NULL,
    "Identifier" uuid NOT NULL,
    "Name" character varying(256) NOT NULL,
    "LoweredName" character varying(256) NOT NULL,
    "Description" character varying(256)
);


ALTER TABLE "IdentityRole" OWNER TO appfx;

--
-- TOC entry 189 (class 1259 OID 16430)
-- Name: IdentityRole_Id_seq; Type: SEQUENCE; Schema: public; Owner: appfx
--

CREATE SEQUENCE "IdentityRole_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "IdentityRole_Id_seq" OWNER TO appfx;

--
-- TOC entry 2184 (class 0 OID 0)
-- Dependencies: 189
-- Name: IdentityRole_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: appfx
--

ALTER SEQUENCE "IdentityRole_Id_seq" OWNED BY "IdentityRole"."Id";


--
-- TOC entry 188 (class 1259 OID 16421)
-- Name: IdentityUser; Type: TABLE; Schema: public; Owner: appfx
--

CREATE TABLE "IdentityUser" (
    "AccessFailedCount" boolean NOT NULL,
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
    "LockedOutTill" timestamp with time zone
);


ALTER TABLE "IdentityUser" OWNER TO appfx;

--
-- TOC entry 192 (class 1259 OID 16443)
-- Name: IdentityUserLogin; Type: TABLE; Schema: public; Owner: appfx
--

CREATE TABLE "IdentityUserLogin" (
    "Id" integer NOT NULL,
    "ProviderName" character varying(255) NOT NULL,
    "ProviderKey" character varying(45) NOT NULL,
    "ProviderDisplayName" character varying(255),
    "UserId" uuid NOT NULL
);


ALTER TABLE "IdentityUserLogin" OWNER TO appfx;

--
-- TOC entry 191 (class 1259 OID 16441)
-- Name: IdentityUserLogin_Id_seq; Type: SEQUENCE; Schema: public; Owner: appfx
--

CREATE SEQUENCE "IdentityUserLogin_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "IdentityUserLogin_Id_seq" OWNER TO appfx;

--
-- TOC entry 2185 (class 0 OID 0)
-- Dependencies: 191
-- Name: IdentityUserLogin_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: appfx
--

ALTER SEQUENCE "IdentityUserLogin_Id_seq" OWNED BY "IdentityUserLogin"."Id";


--
-- TOC entry 194 (class 1259 OID 16454)
-- Name: IdentityUserRole; Type: TABLE; Schema: public; Owner: appfx
--

CREATE TABLE "IdentityUserRole" (
    "Id" integer NOT NULL,
    "UserId" integer NOT NULL,
    "RoleId" integer NOT NULL
);


ALTER TABLE "IdentityUserRole" OWNER TO appfx;

--
-- TOC entry 193 (class 1259 OID 16452)
-- Name: IdentityUserRole_Id_seq; Type: SEQUENCE; Schema: public; Owner: appfx
--

CREATE SEQUENCE "IdentityUserRole_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "IdentityUserRole_Id_seq" OWNER TO appfx;

--
-- TOC entry 2186 (class 0 OID 0)
-- Dependencies: 193
-- Name: IdentityUserRole_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: appfx
--

ALTER SEQUENCE "IdentityUserRole_Id_seq" OWNED BY "IdentityUserRole"."Id";


--
-- TOC entry 187 (class 1259 OID 16419)
-- Name: IdentityUser_Id_seq; Type: SEQUENCE; Schema: public; Owner: appfx
--

CREATE SEQUENCE "IdentityUser_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "IdentityUser_Id_seq" OWNER TO appfx;

--
-- TOC entry 2187 (class 0 OID 0)
-- Dependencies: 187
-- Name: IdentityUser_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: appfx
--

ALTER SEQUENCE "IdentityUser_Id_seq" OWNED BY "IdentityUser"."Id";


--
-- TOC entry 196 (class 1259 OID 16462)
-- Name: identityClaim; Type: TABLE; Schema: public; Owner: appfx
--

CREATE TABLE "identityClaim" (
    "Id" integer NOT NULL,
    "UserId" integer NOT NULL,
    "Type" character varying(256) NOT NULL,
    "Value" character varying(256)
);


ALTER TABLE "identityClaim" OWNER TO appfx;

--
-- TOC entry 195 (class 1259 OID 16460)
-- Name: identityClaim_Id_seq; Type: SEQUENCE; Schema: public; Owner: appfx
--

CREATE SEQUENCE "identityClaim_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "identityClaim_Id_seq" OWNER TO appfx;

--
-- TOC entry 2188 (class 0 OID 0)
-- Dependencies: 195
-- Name: identityClaim_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: appfx
--

ALTER SEQUENCE "identityClaim_Id_seq" OWNED BY "identityClaim"."Id";


--
-- TOC entry 2035 (class 2604 OID 16416)
-- Name: Dummy Id; Type: DEFAULT; Schema: public; Owner: appfx
--

ALTER TABLE ONLY "Dummy" ALTER COLUMN "Id" SET DEFAULT nextval('"Dummy_Id_seq"'::regclass);


--
-- TOC entry 2037 (class 2604 OID 16435)
-- Name: IdentityRole Id; Type: DEFAULT; Schema: public; Owner: appfx
--

ALTER TABLE ONLY "IdentityRole" ALTER COLUMN "Id" SET DEFAULT nextval('"IdentityRole_Id_seq"'::regclass);


--
-- TOC entry 2036 (class 2604 OID 16424)
-- Name: IdentityUser Id; Type: DEFAULT; Schema: public; Owner: appfx
--

ALTER TABLE ONLY "IdentityUser" ALTER COLUMN "Id" SET DEFAULT nextval('"IdentityUser_Id_seq"'::regclass);


--
-- TOC entry 2038 (class 2604 OID 16446)
-- Name: IdentityUserLogin Id; Type: DEFAULT; Schema: public; Owner: appfx
--

ALTER TABLE ONLY "IdentityUserLogin" ALTER COLUMN "Id" SET DEFAULT nextval('"IdentityUserLogin_Id_seq"'::regclass);


--
-- TOC entry 2039 (class 2604 OID 16457)
-- Name: IdentityUserRole Id; Type: DEFAULT; Schema: public; Owner: appfx
--

ALTER TABLE ONLY "IdentityUserRole" ALTER COLUMN "Id" SET DEFAULT nextval('"IdentityUserRole_Id_seq"'::regclass);


--
-- TOC entry 2040 (class 2604 OID 16465)
-- Name: identityClaim Id; Type: DEFAULT; Schema: public; Owner: appfx
--

ALTER TABLE ONLY "identityClaim" ALTER COLUMN "Id" SET DEFAULT nextval('"identityClaim_Id_seq"'::regclass);


--
-- TOC entry 2042 (class 2606 OID 16418)
-- Name: Dummy Dummy_pkey; Type: CONSTRAINT; Schema: public; Owner: appfx
--

ALTER TABLE ONLY "Dummy"
    ADD CONSTRAINT "Dummy_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2048 (class 2606 OID 16440)
-- Name: IdentityRole IdentityRole_pkey; Type: CONSTRAINT; Schema: public; Owner: appfx
--

ALTER TABLE ONLY "IdentityRole"
    ADD CONSTRAINT "IdentityRole_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2050 (class 2606 OID 16451)
-- Name: IdentityUserLogin IdentityUserLogin_pkey; Type: CONSTRAINT; Schema: public; Owner: appfx
--

ALTER TABLE ONLY "IdentityUserLogin"
    ADD CONSTRAINT "IdentityUserLogin_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2052 (class 2606 OID 16459)
-- Name: IdentityUserRole IdentityUserRole_pkey; Type: CONSTRAINT; Schema: public; Owner: appfx
--

ALTER TABLE ONLY "IdentityUserRole"
    ADD CONSTRAINT "IdentityUserRole_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2044 (class 2606 OID 16429)
-- Name: IdentityUser IdentityUser_pkey; Type: CONSTRAINT; Schema: public; Owner: appfx
--

ALTER TABLE ONLY "IdentityUser"
    ADD CONSTRAINT "IdentityUser_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2046 (class 2606 OID 16487)
-- Name: IdentityUser UX_Identifier; Type: CONSTRAINT; Schema: public; Owner: appfx
--

ALTER TABLE ONLY "IdentityUser"
    ADD CONSTRAINT "UX_Identifier" UNIQUE ("Identifier");


--
-- TOC entry 2054 (class 2606 OID 16470)
-- Name: identityClaim identityClaim_pkey; Type: CONSTRAINT; Schema: public; Owner: appfx
--

ALTER TABLE ONLY "identityClaim"
    ADD CONSTRAINT "identityClaim_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2058 (class 2606 OID 16471)
-- Name: identityClaim FK_IdentityClaim_IdentityUser; Type: FK CONSTRAINT; Schema: public; Owner: appfx
--

ALTER TABLE ONLY "identityClaim"
    ADD CONSTRAINT "FK_IdentityClaim_IdentityUser" FOREIGN KEY ("UserId") REFERENCES "IdentityUser"("Id");


--
-- TOC entry 2055 (class 2606 OID 16488)
-- Name: IdentityUserLogin FK_IdentityUserLogin_IdentityUser; Type: FK CONSTRAINT; Schema: public; Owner: appfx
--

ALTER TABLE ONLY "IdentityUserLogin"
    ADD CONSTRAINT "FK_IdentityUserLogin_IdentityUser" FOREIGN KEY ("UserId") REFERENCES "IdentityUser"("Identifier");


--
-- TOC entry 2056 (class 2606 OID 16476)
-- Name: IdentityUserRole FK_IdentityUserRole_IdentityRole; Type: FK CONSTRAINT; Schema: public; Owner: appfx
--

ALTER TABLE ONLY "IdentityUserRole"
    ADD CONSTRAINT "FK_IdentityUserRole_IdentityRole" FOREIGN KEY ("RoleId") REFERENCES "IdentityRole"("Id");


--
-- TOC entry 2057 (class 2606 OID 16481)
-- Name: IdentityUserRole FK_IdentityUserRole_IdentityUser; Type: FK CONSTRAINT; Schema: public; Owner: appfx
--

ALTER TABLE ONLY "IdentityUserRole"
    ADD CONSTRAINT "FK_IdentityUserRole_IdentityUser" FOREIGN KEY ("UserId") REFERENCES "IdentityUser"("Id");


-- Completed on 2017-08-20 17:39:06

--
-- PostgreSQL database dump complete
--

