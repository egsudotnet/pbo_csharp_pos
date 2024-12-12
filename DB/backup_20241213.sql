--
-- PostgreSQL database dump
--

-- Dumped from database version 16.1
-- Dumped by pg_dump version 16.0

-- Started on 2024-12-13 05:48:25

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 216 (class 1259 OID 41311)
-- Name: Barang; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Barang" (
    "Id" integer NOT NULL,
    "Nama" character varying(100) NOT NULL,
    "HargaJual" numeric(10,2) NOT NULL,
    "Stok" integer NOT NULL
);


ALTER TABLE public."Barang" OWNER TO postgres;

--
-- TOC entry 220 (class 1259 OID 41389)
-- Name: DetailPenjualan; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."DetailPenjualan" (
    "Id" integer NOT NULL,
    "PenjualanId" integer NOT NULL,
    "BarangId" integer NOT NULL,
    "Jumlah" integer NOT NULL,
    "Harga" numeric(18,2) NOT NULL
);


ALTER TABLE public."DetailPenjualan" OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 41388)
-- Name: DetailPenjualan_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."DetailPenjualan_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."DetailPenjualan_Id_seq" OWNER TO postgres;

--
-- TOC entry 4854 (class 0 OID 0)
-- Dependencies: 219
-- Name: DetailPenjualan_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."DetailPenjualan_Id_seq" OWNED BY public."DetailPenjualan"."Id";


--
-- TOC entry 218 (class 1259 OID 41382)
-- Name: Penjualan; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Penjualan" (
    "Id" integer NOT NULL,
    "Tanggal" timestamp without time zone NOT NULL,
    "TotalHarga" numeric(18,2) NOT NULL
);


ALTER TABLE public."Penjualan" OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 41381)
-- Name: Penjualan_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Penjualan_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Penjualan_Id_seq" OWNER TO postgres;

--
-- TOC entry 4855 (class 0 OID 0)
-- Dependencies: 217
-- Name: Penjualan_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Penjualan_Id_seq" OWNED BY public."Penjualan"."Id";


--
-- TOC entry 215 (class 1259 OID 41310)
-- Name: barang_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.barang_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.barang_id_seq OWNER TO postgres;

--
-- TOC entry 4856 (class 0 OID 0)
-- Dependencies: 215
-- Name: barang_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.barang_id_seq OWNED BY public."Barang"."Id";


--
-- TOC entry 4695 (class 2604 OID 41314)
-- Name: Barang Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Barang" ALTER COLUMN "Id" SET DEFAULT nextval('public.barang_id_seq'::regclass);


--
-- TOC entry 4697 (class 2604 OID 41392)
-- Name: DetailPenjualan Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."DetailPenjualan" ALTER COLUMN "Id" SET DEFAULT nextval('public."DetailPenjualan_Id_seq"'::regclass);


--
-- TOC entry 4696 (class 2604 OID 41385)
-- Name: Penjualan Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Penjualan" ALTER COLUMN "Id" SET DEFAULT nextval('public."Penjualan_Id_seq"'::regclass);


--
-- TOC entry 4703 (class 2606 OID 41394)
-- Name: DetailPenjualan DetailPenjualan_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."DetailPenjualan"
    ADD CONSTRAINT "DetailPenjualan_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4701 (class 2606 OID 41387)
-- Name: Penjualan Penjualan_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Penjualan"
    ADD CONSTRAINT "Penjualan_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4699 (class 2606 OID 41316)
-- Name: Barang barang_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Barang"
    ADD CONSTRAINT barang_pkey PRIMARY KEY ("Id");


--
-- TOC entry 4704 (class 2606 OID 41400)
-- Name: DetailPenjualan DetailPenjualan_BarangId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."DetailPenjualan"
    ADD CONSTRAINT "DetailPenjualan_BarangId_fkey" FOREIGN KEY ("BarangId") REFERENCES public."Barang"("Id");


--
-- TOC entry 4705 (class 2606 OID 41395)
-- Name: DetailPenjualan DetailPenjualan_PenjualanId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."DetailPenjualan"
    ADD CONSTRAINT "DetailPenjualan_PenjualanId_fkey" FOREIGN KEY ("PenjualanId") REFERENCES public."Penjualan"("Id");


-- Completed on 2024-12-13 05:48:25

--
-- PostgreSQL database dump complete
--

