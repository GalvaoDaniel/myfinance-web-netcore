
-- Create Data Base

CREATE DATABASE myfinance
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'pt_BR.UTF-8'
    LC_CTYPE = 'pt_BR.UTF-8'
    LOCALE_PROVIDER = 'libc'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;


-- Create squema

CREATE SCHEMA IF NOT EXISTS public
    AUTHORIZATION pg_database_owner;

COMMENT ON SCHEMA public
    IS 'standard public schema';

GRANT USAGE ON SCHEMA public TO PUBLIC;

GRANT ALL ON SCHEMA public TO pg_database_owner;


-- Create Tables

CREATE TABLE IF NOT EXISTS public."PlanoConta"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    "Descricao" character varying(50) COLLATE pg_catalog."default" NOT NULL,
    "Tipo" character(1) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT Planoconta_pkey PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."PlanoConta"
    OWNER to postgres;

CREATE TABLE IF NOT EXISTS public."Transacao"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    "Historico" character varying COLLATE pg_catalog."default",
    "Data" timestamp with time zone NOT NULL,
    "Valor" numeric(9,2) NOT NULL,
    "PlanoContaId" integer NOT NULL,
    CONSTRAINT "Transacao_pkey" PRIMARY KEY ("Id"),
    CONSTRAINT "planoconta_foreignKey" FOREIGN KEY ("PlanoContaId")
        REFERENCES public."PlanoConta" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Transacao"
    OWNER to postgres;


-- Creation of initial data, if necessary.
/*
insert into public."PlanoConta"("Descricao", "Tipo")
values ('Combustivel', 'D');

insert into public."PlanoConta"("Descricao", "Tipo")
values ('Alimentacao', 'D');

insert into public."PlanoConta"("Descricao", "Tipo")
values ('Educacao', 'D');

insert into public."PlanoConta"("Descricao", "Tipo")
values ('Salario', 'R');

insert into public."PlanoConta"("Descricao", "Tipo")
values ('Juros', 'R');

insert into public."Transacao"("Historico", "Data", "Valor", "PlanoContaId")
values ('Gasolina Blazer', '2024-05-19 14:00', 360, 1);

insert into public."Transacao"("Historico", "Data", "Valor", "PlanoContaId")
values ('Almoço', '2024-05-19 12:00', 120, 2);

*/