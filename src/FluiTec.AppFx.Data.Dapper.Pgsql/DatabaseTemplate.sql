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

-- Completed on 2017-08-20 17:39:06

--
-- PostgreSQL database dump complete
--

