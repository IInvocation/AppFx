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
CREATE TABLE "Dummy" (
    "Id" integer NOT NULL,
    "Name" character varying(256)
);
ALTER TABLE "Dummy" OWNER TO appfx;
CREATE SEQUENCE "Dummy_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER TABLE "Dummy_Id_seq" OWNER TO appfx;
ALTER SEQUENCE "Dummy_Id_seq" OWNED BY "Dummy"."Id";
ALTER TABLE ONLY "Dummy" ALTER COLUMN "Id" SET DEFAULT nextval('"Dummy_Id_seq"'::regclass);
ALTER TABLE ONLY "Dummy"
    ADD CONSTRAINT "Dummy_pkey" PRIMARY KEY ("Id");