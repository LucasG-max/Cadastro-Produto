-- ================================================================
-- SCRIPT PARA CRIAR O BANCO DE DADOS E A TABELA DE PRODUTOS
-- Execute este script no seu MySQL (Workbench, phpMyAdmin ou linha de comando)
-- ================================================================

-- Cria o banco de dados se nao existir
CREATE DATABASE IF NOT EXISTS cadastro_produtos
CHARACTER SET utf8mb4
COLLATE utf8mb4_unicode_ci;

-- Seleciona o banco de dados
USE cadastro_produtos;

-- Cria a tabela de produtos se nao existir
CREATE TABLE IF NOT EXISTS produtos (
    codigo_interno VARCHAR(50) NOT NULL PRIMARY KEY COMMENT 'Codigo interno do produto (identificador unico)',
    codigo_barra VARCHAR(100) NULL COMMENT 'Codigo de barras do produto (EAN, GTIN, etc)',
    descricao VARCHAR(255) NOT NULL COMMENT 'Descricao/nome do produto',
    quantidade INT NOT NULL DEFAULT 0 COMMENT 'Quantidade em estoque',
    preco_custo DECIMAL(10,2) NOT NULL DEFAULT 0.00 COMMENT 'Preco de custo do produto',
    preco_venda DECIMAL(10,2) NOT NULL DEFAULT 0.00 COMMENT 'Preco de venda do produto',
    caminho_foto VARCHAR(255) NULL COMMENT 'Caminho completo do arquivo de foto do produto no computador/servidor'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- (OPCIONAL) Insere alguns produtos de exemplo para teste
INSERT INTO produtos (codigo_interno, codigo_barra, descricao, quantidade, preco_custo, preco_venda, caminho_foto) VALUES
('P001', '7891000100010', 'Camiseta Branca M', 50, 15.00, 39.90, ''),
('P002', '7891000100027', 'Calca Jeans Azul 42', 30, 45.00, 99.90, ''),
('P003', '7891000100034', 'Tenis Esportivo Preto 40', 20, 80.00, 199.90, '')
ON DUPLICATE KEY UPDATE descricao = VALUES(descricao);

-- Exibe os produtos cadastrados para confirmar
SELECT * FROM produtos;
