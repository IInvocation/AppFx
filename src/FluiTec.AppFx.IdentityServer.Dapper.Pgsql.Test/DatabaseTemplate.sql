SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;
CREATE SCHEMA "AppFxIdentityServer";
ALTER SCHEMA "AppFxIdentityServer" OWNER TO appfx;
CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;
COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';
SET search_path = "AppFxIdentityServer", pg_catalog;
SET default_tablespace = '';
SET default_with_oids = false;
CREATE TABLE "ApiResource" (
    "Id" integer NOT NULL,
    "Name" character varying(255) NOT NULL,
    "DisplayName" character varying(255) NOT NULL,
    "Description" character varying,
    "Enabled" boolean NOT NULL
);
ALTER TABLE "ApiResource" OWNER TO appfx;
CREATE TABLE "ApiResourceClaim" (
    "Id" integer NOT NULL,
    "ApiResourceId" integer NOT NULL,
    "ClaimType" character varying(255) NOT NULL
);
ALTER TABLE "ApiResourceClaim" OWNER TO appfx;
CREATE SEQUENCE "ApiResourceClaim_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER TABLE "ApiResourceClaim_Id_seq" OWNER TO appfx;
ALTER SEQUENCE "ApiResourceClaim_Id_seq" OWNED BY "ApiResourceClaim"."Id";
CREATE TABLE "ApiResourceScope" (
    "Id" integer NOT NULL,
    "ApiResourceId" integer NOT NULL,
    "ScopeId" integer NOT NULL
);
ALTER TABLE "ApiResourceScope" OWNER TO appfx;
CREATE SEQUENCE "ApiResourceScope_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER TABLE "ApiResourceScope_Id_seq" OWNER TO appfx;
ALTER SEQUENCE "ApiResourceScope_Id_seq" OWNED BY "ApiResourceScope"."Id";
CREATE SEQUENCE "ApiResource_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER TABLE "ApiResource_Id_seq" OWNER TO appfx;
ALTER SEQUENCE "ApiResource_Id_seq" OWNED BY "ApiResource"."Id";
CREATE TABLE "Client" (
    "Id" integer NOT NULL,
    "ClientId" character varying(255) NOT NULL,
    "Name" character varying(255),
    "Secret" character varying NOT NULL,
    "RedirectUri" character varying,
    "PostLogoutUri" character varying,
    "AllowOfflineAccess" boolean NOT NULL,
    "GrantTypes" character varying NOT NULL
);
ALTER TABLE "Client" OWNER TO appfx;
CREATE TABLE "ClientClaim" (
    "Id" integer NOT NULL,
    "ClientId" integer NOT NULL,
    "ClaimType" character varying(255) NOT NULL,
    "ClaimValue" character varying(255)
);
ALTER TABLE "ClientClaim" OWNER TO appfx;
CREATE SEQUENCE "ClientClaim_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER TABLE "ClientClaim_Id_seq" OWNER TO appfx;
ALTER SEQUENCE "ClientClaim_Id_seq" OWNED BY "ClientClaim"."Id";
CREATE TABLE "ClientScope" (
    "Id" integer NOT NULL,
    "ClientId" integer NOT NULL,
    "ScopeId" integer NOT NULL
);
ALTER TABLE "ClientScope" OWNER TO appfx;
CREATE SEQUENCE "ClientScope_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER TABLE "ClientScope_Id_seq" OWNER TO appfx;
ALTER SEQUENCE "ClientScope_Id_seq" OWNED BY "ClientScope"."Id";
CREATE SEQUENCE "Client_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER TABLE "Client_Id_seq" OWNER TO appfx;
ALTER SEQUENCE "Client_Id_seq" OWNED BY "Client"."Id";
CREATE TABLE "Grant" (
    "Id" integer NOT NULL,
    "GrantKey" character varying(255) NOT NULL,
    "Type" character varying(255) NOT NULL,
    "SubjectId" character varying(255) NOT NULL,
    "ClientId" character varying(255) NOT NULL,
    "CreationTime" timestamp without time zone NOT NULL,
    "Expiration" timestamp without time zone,
    "Data" character varying NOT NULL
);
ALTER TABLE "Grant" OWNER TO appfx;
CREATE SEQUENCE "Grant_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "Grant_Id_seq" OWNER TO appfx;

--
-- TOC entry 2246 (class 0 OID 0)
-- Dependencies: 199
-- Name: Grant_Id_seq; Type: SEQUENCE OWNED BY; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER SEQUENCE "Grant_Id_seq" OWNED BY "Grant"."Id";


--
-- TOC entry 202 (class 1259 OID 16954)
-- Name: IdentityResource; Type: TABLE; Schema: AppFxIdentityServer; Owner: appfx
--

CREATE TABLE "IdentityResource" (
    "Id" integer NOT NULL,
    "Name" character varying(255) NOT NULL,
    "DisplayName" character varying(255) NOT NULL,
    "Description" character varying,
    "Enabled" boolean NOT NULL,
    "Required" boolean NOT NULL,
    "Emphasize" boolean NOT NULL,
    "ShowInDiscoveryDocument" boolean NOT NULL
);


ALTER TABLE "IdentityResource" OWNER TO appfx;

--
-- TOC entry 204 (class 1259 OID 16966)
-- Name: IdentityResourceClaim; Type: TABLE; Schema: AppFxIdentityServer; Owner: appfx
--

CREATE TABLE "IdentityResourceClaim" (
    "Id" integer NOT NULL,
    "IdentityResourceId" integer NOT NULL,
    "ClaimType" character varying(255) NOT NULL
);


ALTER TABLE "IdentityResourceClaim" OWNER TO appfx;

--
-- TOC entry 203 (class 1259 OID 16964)
-- Name: IdentityResourceClaim_Id_seq; Type: SEQUENCE; Schema: AppFxIdentityServer; Owner: appfx
--

CREATE SEQUENCE "IdentityResourceClaim_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "IdentityResourceClaim_Id_seq" OWNER TO appfx;

--
-- TOC entry 2247 (class 0 OID 0)
-- Dependencies: 203
-- Name: IdentityResourceClaim_Id_seq; Type: SEQUENCE OWNED BY; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER SEQUENCE "IdentityResourceClaim_Id_seq" OWNED BY "IdentityResourceClaim"."Id";


--
-- TOC entry 206 (class 1259 OID 16979)
-- Name: IdentityResourceScope; Type: TABLE; Schema: AppFxIdentityServer; Owner: appfx
--

CREATE TABLE "IdentityResourceScope" (
    "Id" integer NOT NULL,
    "IdentityResourceId" integer NOT NULL,
    "ScopeId" integer NOT NULL
);


ALTER TABLE "IdentityResourceScope" OWNER TO appfx;

--
-- TOC entry 205 (class 1259 OID 16977)
-- Name: IdentityResourceScope_Id_seq; Type: SEQUENCE; Schema: AppFxIdentityServer; Owner: appfx
--

CREATE SEQUENCE "IdentityResourceScope_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "IdentityResourceScope_Id_seq" OWNER TO appfx;

--
-- TOC entry 2248 (class 0 OID 0)
-- Dependencies: 205
-- Name: IdentityResourceScope_Id_seq; Type: SEQUENCE OWNED BY; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER SEQUENCE "IdentityResourceScope_Id_seq" OWNED BY "IdentityResourceScope"."Id";


--
-- TOC entry 201 (class 1259 OID 16952)
-- Name: IdentityResource_Id_seq; Type: SEQUENCE; Schema: AppFxIdentityServer; Owner: appfx
--

CREATE SEQUENCE "IdentityResource_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "IdentityResource_Id_seq" OWNER TO appfx;

--
-- TOC entry 2249 (class 0 OID 0)
-- Dependencies: 201
-- Name: IdentityResource_Id_seq; Type: SEQUENCE OWNED BY; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER SEQUENCE "IdentityResource_Id_seq" OWNED BY "IdentityResource"."Id";


--
-- TOC entry 190 (class 1259 OID 16871)
-- Name: Scope; Type: TABLE; Schema: AppFxIdentityServer; Owner: appfx
--

CREATE TABLE "Scope" (
    "Id" integer NOT NULL,
    "Name" character varying(255) NOT NULL,
    "DisplayName" character varying(255) NOT NULL,
    "Description" character varying,
    "Required" boolean NOT NULL,
    "Emphasize" boolean NOT NULL,
    "ShowInDiscoveryDocument" boolean NOT NULL
);


ALTER TABLE "Scope" OWNER TO appfx;

--
-- TOC entry 189 (class 1259 OID 16869)
-- Name: Scope_Id_seq; Type: SEQUENCE; Schema: AppFxIdentityServer; Owner: appfx
--

CREATE SEQUENCE "Scope_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "Scope_Id_seq" OWNER TO appfx;

--
-- TOC entry 2250 (class 0 OID 0)
-- Dependencies: 189
-- Name: Scope_Id_seq; Type: SEQUENCE OWNED BY; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER SEQUENCE "Scope_Id_seq" OWNED BY "Scope"."Id";


--
-- TOC entry 208 (class 1259 OID 16997)
-- Name: SigningCredential; Type: TABLE; Schema: AppFxIdentityServer; Owner: appfx
--

CREATE TABLE "SigningCredential" (
    "Id" integer NOT NULL,
    "Issued" timestamp without time zone NOT NULL,
    "Contents" character varying NOT NULL
);


ALTER TABLE "SigningCredential" OWNER TO appfx;

--
-- TOC entry 207 (class 1259 OID 16995)
-- Name: SigningCredential_Id_seq; Type: SEQUENCE; Schema: AppFxIdentityServer; Owner: appfx
--

CREATE SEQUENCE "SigningCredential_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "SigningCredential_Id_seq" OWNER TO appfx;

--
-- TOC entry 2251 (class 0 OID 0)
-- Dependencies: 207
-- Name: SigningCredential_Id_seq; Type: SEQUENCE OWNED BY; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER SEQUENCE "SigningCredential_Id_seq" OWNED BY "SigningCredential"."Id";


--
-- TOC entry 2074 (class 2604 OID 16850)
-- Name: ApiResource Id; Type: DEFAULT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "ApiResource" ALTER COLUMN "Id" SET DEFAULT nextval('"ApiResource_Id_seq"'::regclass);


--
-- TOC entry 2075 (class 2604 OID 16861)
-- Name: ApiResourceClaim Id; Type: DEFAULT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "ApiResourceClaim" ALTER COLUMN "Id" SET DEFAULT nextval('"ApiResourceClaim_Id_seq"'::regclass);


--
-- TOC entry 2077 (class 2604 OID 16885)
-- Name: ApiResourceScope Id; Type: DEFAULT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "ApiResourceScope" ALTER COLUMN "Id" SET DEFAULT nextval('"ApiResourceScope_Id_seq"'::regclass);


--
-- TOC entry 2078 (class 2604 OID 16903)
-- Name: Client Id; Type: DEFAULT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "Client" ALTER COLUMN "Id" SET DEFAULT nextval('"Client_Id_seq"'::regclass);


--
-- TOC entry 2079 (class 2604 OID 16914)
-- Name: ClientClaim Id; Type: DEFAULT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "ClientClaim" ALTER COLUMN "Id" SET DEFAULT nextval('"ClientClaim_Id_seq"'::regclass);


--
-- TOC entry 2080 (class 2604 OID 16928)
-- Name: ClientScope Id; Type: DEFAULT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "ClientScope" ALTER COLUMN "Id" SET DEFAULT nextval('"ClientScope_Id_seq"'::regclass);


--
-- TOC entry 2081 (class 2604 OID 16946)
-- Name: Grant Id; Type: DEFAULT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "Grant" ALTER COLUMN "Id" SET DEFAULT nextval('"Grant_Id_seq"'::regclass);


--
-- TOC entry 2082 (class 2604 OID 16957)
-- Name: IdentityResource Id; Type: DEFAULT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "IdentityResource" ALTER COLUMN "Id" SET DEFAULT nextval('"IdentityResource_Id_seq"'::regclass);


--
-- TOC entry 2083 (class 2604 OID 16969)
-- Name: IdentityResourceClaim Id; Type: DEFAULT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "IdentityResourceClaim" ALTER COLUMN "Id" SET DEFAULT nextval('"IdentityResourceClaim_Id_seq"'::regclass);


--
-- TOC entry 2084 (class 2604 OID 16982)
-- Name: IdentityResourceScope Id; Type: DEFAULT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "IdentityResourceScope" ALTER COLUMN "Id" SET DEFAULT nextval('"IdentityResourceScope_Id_seq"'::regclass);


--
-- TOC entry 2076 (class 2604 OID 16874)
-- Name: Scope Id; Type: DEFAULT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "Scope" ALTER COLUMN "Id" SET DEFAULT nextval('"Scope_Id_seq"'::regclass);


--
-- TOC entry 2085 (class 2604 OID 17000)
-- Name: SigningCredential Id; Type: DEFAULT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "SigningCredential" ALTER COLUMN "Id" SET DEFAULT nextval('"SigningCredential_Id_seq"'::regclass);


--
-- TOC entry 2089 (class 2606 OID 16863)
-- Name: ApiResourceClaim ApiResourceClaim_pkey; Type: CONSTRAINT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "ApiResourceClaim"
    ADD CONSTRAINT "ApiResourceClaim_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2093 (class 2606 OID 16887)
-- Name: ApiResourceScope ApiResourceScope_pkey; Type: CONSTRAINT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "ApiResourceScope"
    ADD CONSTRAINT "ApiResourceScope_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2087 (class 2606 OID 16855)
-- Name: ApiResource ApiResource_pkey; Type: CONSTRAINT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "ApiResource"
    ADD CONSTRAINT "ApiResource_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2097 (class 2606 OID 16930)
-- Name: ClientScope ClientScope_pkey; Type: CONSTRAINT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "ClientScope"
    ADD CONSTRAINT "ClientScope_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2095 (class 2606 OID 16908)
-- Name: Client Client_pkey; Type: CONSTRAINT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "Client"
    ADD CONSTRAINT "Client_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2099 (class 2606 OID 16951)
-- Name: Grant Grant_pkey; Type: CONSTRAINT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "Grant"
    ADD CONSTRAINT "Grant_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2103 (class 2606 OID 16971)
-- Name: IdentityResourceClaim IdentityResourceClaim_pkey; Type: CONSTRAINT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "IdentityResourceClaim"
    ADD CONSTRAINT "IdentityResourceClaim_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2105 (class 2606 OID 16984)
-- Name: IdentityResourceScope IdentityResourceScope_pkey; Type: CONSTRAINT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "IdentityResourceScope"
    ADD CONSTRAINT "IdentityResourceScope_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2101 (class 2606 OID 16962)
-- Name: IdentityResource IdentityResource_pkey; Type: CONSTRAINT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "IdentityResource"
    ADD CONSTRAINT "IdentityResource_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2091 (class 2606 OID 16879)
-- Name: Scope Scope_pkey; Type: CONSTRAINT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "Scope"
    ADD CONSTRAINT "Scope_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2107 (class 2606 OID 17005)
-- Name: SigningCredential SigningCredential_pkey; Type: CONSTRAINT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "SigningCredential"
    ADD CONSTRAINT "SigningCredential_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2108 (class 2606 OID 16864)
-- Name: ApiResourceClaim FK_ApiResourceClaim_ApiResource; Type: FK CONSTRAINT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "ApiResourceClaim"
    ADD CONSTRAINT "FK_ApiResourceClaim_ApiResource" FOREIGN KEY ("ApiResourceId") REFERENCES "ApiResource"("Id");


--
-- TOC entry 2109 (class 2606 OID 16888)
-- Name: ApiResourceScope FK_ApiResourceScope_ApiResource; Type: FK CONSTRAINT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "ApiResourceScope"
    ADD CONSTRAINT "FK_ApiResourceScope_ApiResource" FOREIGN KEY ("ApiResourceId") REFERENCES "ApiResource"("Id");


--
-- TOC entry 2110 (class 2606 OID 16893)
-- Name: ApiResourceScope FK_ApiResourceScope_Scope; Type: FK CONSTRAINT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "ApiResourceScope"
    ADD CONSTRAINT "FK_ApiResourceScope_Scope" FOREIGN KEY ("ScopeId") REFERENCES "Scope"("Id");


--
-- TOC entry 2111 (class 2606 OID 16918)
-- Name: ClientClaim FK_ClientClaim_Client; Type: FK CONSTRAINT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "ClientClaim"
    ADD CONSTRAINT "FK_ClientClaim_Client" FOREIGN KEY ("ClientId") REFERENCES "Client"("Id");


--
-- TOC entry 2113 (class 2606 OID 16936)
-- Name: ClientScope FK_ClientScope_Client; Type: FK CONSTRAINT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "ClientScope"
    ADD CONSTRAINT "FK_ClientScope_Client" FOREIGN KEY ("ClientId") REFERENCES "Client"("Id");


--
-- TOC entry 2112 (class 2606 OID 16931)
-- Name: ClientScope FK_ClientScope_Scope; Type: FK CONSTRAINT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "ClientScope"
    ADD CONSTRAINT "FK_ClientScope_Scope" FOREIGN KEY ("ScopeId") REFERENCES "Scope"("Id");


--
-- TOC entry 2114 (class 2606 OID 16972)
-- Name: IdentityResourceClaim FK_IdentityResourceClaim_IdentityResource; Type: FK CONSTRAINT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "IdentityResourceClaim"
    ADD CONSTRAINT "FK_IdentityResourceClaim_IdentityResource" FOREIGN KEY ("IdentityResourceId") REFERENCES "IdentityResource"("Id");


--
-- TOC entry 2115 (class 2606 OID 16985)
-- Name: IdentityResourceScope FK_IdentityResourceScope_IdentityResource; Type: FK CONSTRAINT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "IdentityResourceScope"
    ADD CONSTRAINT "FK_IdentityResourceScope_IdentityResource" FOREIGN KEY ("IdentityResourceId") REFERENCES "IdentityResource"("Id");


--
-- TOC entry 2116 (class 2606 OID 16990)
-- Name: IdentityResourceScope FK_IdentityResourceScope_Scope; Type: FK CONSTRAINT; Schema: AppFxIdentityServer; Owner: appfx
--

ALTER TABLE ONLY "IdentityResourceScope"
    ADD CONSTRAINT "FK_IdentityResourceScope_Scope" FOREIGN KEY ("ScopeId") REFERENCES "Scope"("Id");


-- Completed on 2017-08-28 15:50:25

--
-- PostgreSQL database dump complete
--

