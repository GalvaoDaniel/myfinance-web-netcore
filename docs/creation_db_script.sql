
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

CREATE TABLE IF NOT EXISTS public.Planoconta
(
    id integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    descricao character varying(50) COLLATE pg_catalog."default" NOT NULL,
    tipo character(1) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT Planoconta_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.Planoconta
    OWNER to postgres;

CREATE TABLE IF NOT EXISTS public.Transacao
(
    id integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    historico character varying COLLATE pg_catalog."default",
    data timestamp with time zone NOT NULL,
    valor numeric(9,2) NOT NULL,
    planocontaid integer NOT NULL,
    CONSTRAINT "Transacao_pkey" PRIMARY KEY (id),
    CONSTRAINT "planoconta_foreignKey" FOREIGN KEY (planocontaid)
        REFERENCES public.planoconta (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.Transacao
    OWNER to postgres;


-- Creation of initial data, if necessary.
/*
insert into public.planoconta(descricao, tipo)
values ('Combustivel', 'D');

insert into public.planoconta(descricao, tipo)
values ('Alimentacao', 'D');

insert into public.planoconta(descricao, tipo)
values ('Educacao', 'D');

insert into public.planoconta(descricao, tipo)
values ('Salario', 'R');

insert into public.planoconta(descricao, tipo)
values ('Juros', 'R');

insert into public.transacao(historico, data, valor, planocontaid)
values ('Gasolina Blazer', '2024-05-19 14:00', 360, 1);

insert into public.transacao(historico, data, valor, planocontaid)
values ('Almoço', '2024-05-19 12:00', 120, 2);

*/