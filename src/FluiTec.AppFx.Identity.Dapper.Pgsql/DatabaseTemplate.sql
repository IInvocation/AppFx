--
-- PostgreSQL database dump
--

-- Dumped from database version 9.6.2
-- Dumped by pg_dump version 9.6.3

-- Started on 2017-08-16 16:51:33

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
-- TOC entry 2181 (class 0 OID 0)
-- Dependencies: 1
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 192 (class 1259 OID 16445)
-- Name: IdentityClaim; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "IdentityClaim" (
    "Id" integer NOT NULL,
    "UserId" integer NOT NULL,
    "Type" character varying(256) NOT NULL,
    "Value" character varying(256)
);


ALTER TABLE "IdentityClaim" OWNER TO postgres;

--
-- TOC entry 191 (class 1259 OID 16443)
-- Name: IdentityClaim_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "IdentityClaim_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "IdentityClaim_Id_seq" OWNER TO postgres;

--
-- TOC entry 2182 (class 0 OID 0)
-- Dependencies: 191
-- Name: IdentityClaim_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "IdentityClaim_Id_seq" OWNED BY "IdentityClaim"."Id";


--
-- TOC entry 188 (class 1259 OID 16426)
-- Name: IdentityRole; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "IdentityRole" (
    "Id" integer NOT NULL,
    "Identifier" uuid NOT NULL,
    "ApplicationId" integer NOT NULL,
    "Name" character varying(256) NOT NULL,
    "LoweredName" character varying(256) NOT NULL,
    "Description" character varying(256)
);


ALTER TABLE "IdentityRole" OWNER TO postgres;

--
-- TOC entry 187 (class 1259 OID 16424)
-- Name: IdentityRole_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "IdentityRole_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "IdentityRole_Id_seq" OWNER TO postgres;

--
-- TOC entry 2183 (class 0 OID 0)
-- Dependencies: 187
-- Name: IdentityRole_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "IdentityRole_Id_seq" OWNED BY "IdentityRole"."Id";


--
-- TOC entry 186 (class 1259 OID 16415)
-- Name: IdentityUser; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "IdentityUser" (
    "MobileAlias" character varying(16),
    "NormalizedEmail" character varying(256),
    "PasswordHash" character varying(256),
    "SecurityStamp" character varying(256),
    "Phone" character varying(256),
    "LockedOutTill" timestamp with time zone,
    "AccessFailedCount" integer NOT NULL,
    "LockoutEnabled" boolean NOT NULL,
    "TwoFactorEnabled" boolean NOT NULL,
    "PhoneConfirmed" boolean NOT NULL,
    "EmailConfirmed" boolean NOT NULL,
    "ApplicationId" integer NOT NULL,
    "Email" character varying(256) NOT NULL,
    "Id" integer NOT NULL,
    "Identifier" uuid NOT NULL,
    "IsAnonymous" boolean NOT NULL,
    "LastActivityDate" timestamp without time zone NOT NULL,
    "LoweredUserName" character varying(256) NOT NULL,
    "Name" character varying(256) NOT NULL
);


ALTER TABLE "IdentityUser" OWNER TO postgres;

--
-- TOC entry 194 (class 1259 OID 16476)
-- Name: IdentityUserLogin; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "IdentityUserLogin" (
    "Id" integer NOT NULL,
    "ProviderName" character varying(255) NOT NULL,
    "ProviderKey" character varying(4) NOT NULL,
    "ProviderDisplayName" character varying(255),
    "UserId" integer NOT NULL
);


ALTER TABLE "IdentityUserLogin" OWNER TO postgres;

--
-- TOC entry 193 (class 1259 OID 16474)
-- Name: IdentityUserLogin_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "IdentityUserLogin_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "IdentityUserLogin_Id_seq" OWNER TO postgres;

--
-- TOC entry 2184 (class 0 OID 0)
-- Dependencies: 193
-- Name: IdentityUserLogin_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "IdentityUserLogin_Id_seq" OWNED BY "IdentityUserLogin"."Id";


--
-- TOC entry 190 (class 1259 OID 16437)
-- Name: IdentityUserRole; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "IdentityUserRole" (
    "Id" integer NOT NULL,
    "UserId" integer NOT NULL,
    "RoleId" integer NOT NULL
);


ALTER TABLE "IdentityUserRole" OWNER TO postgres;

--
-- TOC entry 189 (class 1259 OID 16435)
-- Name: IdentityUserRole_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "IdentityUserRole_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "IdentityUserRole_Id_seq" OWNER TO postgres;

--
-- TOC entry 2185 (class 0 OID 0)
-- Dependencies: 189
-- Name: IdentityUserRole_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "IdentityUserRole_Id_seq" OWNED BY "IdentityUserRole"."Id";


--
-- TOC entry 185 (class 1259 OID 16413)
-- Name: IdentityUser_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "IdentityUser_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "IdentityUser_Id_seq" OWNER TO postgres;

--
-- TOC entry 2186 (class 0 OID 0)
-- Dependencies: 185
-- Name: IdentityUser_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "IdentityUser_Id_seq" OWNED BY "IdentityUser"."Id";


--
-- TOC entry 2032 (class 2604 OID 16448)
-- Name: IdentityClaim Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "IdentityClaim" ALTER COLUMN "Id" SET DEFAULT nextval('"IdentityClaim_Id_seq"'::regclass);


--
-- TOC entry 2030 (class 2604 OID 16429)
-- Name: IdentityRole Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "IdentityRole" ALTER COLUMN "Id" SET DEFAULT nextval('"IdentityRole_Id_seq"'::regclass);


--
-- TOC entry 2029 (class 2604 OID 16418)
-- Name: IdentityUser Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "IdentityUser" ALTER COLUMN "Id" SET DEFAULT nextval('"IdentityUser_Id_seq"'::regclass);


--
-- TOC entry 2033 (class 2604 OID 16479)
-- Name: IdentityUserLogin Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "IdentityUserLogin" ALTER COLUMN "Id" SET DEFAULT nextval('"IdentityUserLogin_Id_seq"'::regclass);


--
-- TOC entry 2031 (class 2604 OID 16440)
-- Name: IdentityUserRole Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "IdentityUserRole" ALTER COLUMN "Id" SET DEFAULT nextval('"IdentityUserRole_Id_seq"'::regclass);


--
-- TOC entry 2172 (class 0 OID 16445)
-- Dependencies: 192
-- Data for Name: IdentityClaim; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY "IdentityClaim" ("Id", "UserId", "Type", "Value") FROM stdin;
\.


--
-- TOC entry 2187 (class 0 OID 0)
-- Dependencies: 191
-- Name: IdentityClaim_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('"IdentityClaim_Id_seq"', 1, false);


--
-- TOC entry 2168 (class 0 OID 16426)
-- Dependencies: 188
-- Data for Name: IdentityRole; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY "IdentityRole" ("Id", "Identifier", "ApplicationId", "Name", "LoweredName", "Description") FROM stdin;
\.


--
-- TOC entry 2188 (class 0 OID 0)
-- Dependencies: 187
-- Name: IdentityRole_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('"IdentityRole_Id_seq"', 1, false);


--
-- TOC entry 2166 (class 0 OID 16415)
-- Dependencies: 186
-- Data for Name: IdentityUser; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY "IdentityUser" ("MobileAlias", "NormalizedEmail", "PasswordHash", "SecurityStamp", "Phone", "LockedOutTill", "AccessFailedCount", "LockoutEnabled", "TwoFactorEnabled", "PhoneConfirmed", "EmailConfirmed", "ApplicationId", "Email", "Id", "Identifier", "IsAnonymous", "LastActivityDate", "LoweredUserName", "Name") FROM stdin;
\.


--
-- TOC entry 2174 (class 0 OID 16476)
-- Dependencies: 194
-- Data for Name: IdentityUserLogin; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY "IdentityUserLogin" ("Id", "ProviderName", "ProviderKey", "ProviderDisplayName", "UserId") FROM stdin;
\.


--
-- TOC entry 2189 (class 0 OID 0)
-- Dependencies: 193
-- Name: IdentityUserLogin_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('"IdentityUserLogin_Id_seq"', 1, false);


--
-- TOC entry 2170 (class 0 OID 16437)
-- Dependencies: 190
-- Data for Name: IdentityUserRole; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY "IdentityUserRole" ("Id", "UserId", "RoleId") FROM stdin;
\.


--
-- TOC entry 2190 (class 0 OID 0)
-- Dependencies: 189
-- Name: IdentityUserRole_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('"IdentityUserRole_Id_seq"', 1, false);


--
-- TOC entry 2191 (class 0 OID 0)
-- Dependencies: 185
-- Name: IdentityUser_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('"IdentityUser_Id_seq"', 1, false);


--
-- TOC entry 2041 (class 2606 OID 16453)
-- Name: IdentityClaim IdentityClaim_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "IdentityClaim"
    ADD CONSTRAINT "IdentityClaim_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2037 (class 2606 OID 16434)
-- Name: IdentityRole IdentityRole_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "IdentityRole"
    ADD CONSTRAINT "IdentityRole_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2043 (class 2606 OID 16484)
-- Name: IdentityUserLogin IdentityUserLogin_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "IdentityUserLogin"
    ADD CONSTRAINT "IdentityUserLogin_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2039 (class 2606 OID 16442)
-- Name: IdentityUserRole IdentityUserRole_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "IdentityUserRole"
    ADD CONSTRAINT "IdentityUserRole_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2035 (class 2606 OID 16423)
-- Name: IdentityUser IdentityUser_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "IdentityUser"
    ADD CONSTRAINT "IdentityUser_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2046 (class 2606 OID 16459)
-- Name: IdentityClaim FK_IdentityClaim_IdentityUser; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "IdentityClaim"
    ADD CONSTRAINT "FK_IdentityClaim_IdentityUser" FOREIGN KEY ("UserId") REFERENCES "IdentityUser"("Id");


--
-- TOC entry 2047 (class 2606 OID 16485)
-- Name: IdentityUserLogin FK_IdentityUserLogin; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "IdentityUserLogin"
    ADD CONSTRAINT "FK_IdentityUserLogin" FOREIGN KEY ("UserId") REFERENCES "IdentityUser"("Id");


--
-- TOC entry 2044 (class 2606 OID 16464)
-- Name: IdentityUserRole FK_IdentityUserRole_IdentityRole; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "IdentityUserRole"
    ADD CONSTRAINT "FK_IdentityUserRole_IdentityRole" FOREIGN KEY ("RoleId") REFERENCES "IdentityRole"("Id");


--
-- TOC entry 2045 (class 2606 OID 16469)
-- Name: IdentityUserRole FK_IdentityUserRole_IdentityUser; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "IdentityUserRole"
    ADD CONSTRAINT "FK_IdentityUserRole_IdentityUser" FOREIGN KEY ("UserId") REFERENCES "IdentityUser"("Id");


-- Completed on 2017-08-16 16:51:33

--
-- PostgreSQL database dump complete
--

