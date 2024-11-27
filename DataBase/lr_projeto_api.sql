CREATE DATABASE `lr_projeto_api`;
USE `lr_projeto_api` ;

-- -----------------------------------------------------
-- Table `LR_Projeto_Api`.`Usuario`
-- -----------------------------------------------------
CREATE TABLE `Usuario` (
  `id_usu` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `nome_usu` VARCHAR(150) NOT NULL,
  `genero_usu` INT,
  `email_usu` VARCHAR(150) NOT NULL,
  `cpf_usu` VARCHAR(14) UNIQUE,
  `telefone_usu` VARCHAR(95) NOT NULL,
  `senha_usu` VARCHAR(255) NOT NULL,
  `datanasc_usu` DATE
  );
-- -----------------------------------------------------
-- Table `LR_Projeto_Api`.`Estado`
-- -----------------------------------------------------
CREATE TABLE `Estado` (
  `id_est` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `nome_est` VARCHAR(40) NOT NULL,
  `uf_est` VARCHAR(3)
  );
  
  INSERT INTO `Estado` (`nome_est`, `uf_est`) VALUES
('Acre', 'AC'),
('Alagoas', 'AL'),
('Amapá', 'AP'),
('Amazonas', 'AM'),
('Bahia', 'BA'),
('Ceará', 'CE'),
('Distrito Federal', 'DF'),
('Espírito Santo', 'ES'),
('Goiás', 'GO'),
('Maranhão', 'MA'),
('Mato Grosso', 'MT'),
('Mato Grosso do Sul', 'MS'),
('Minas Gerais', 'MG'),
('Pará', 'PA'),
('Paraíba', 'PB'),
('Paraná', 'PR'),
('Pernambuco', 'PE'),
('Piauí', 'PI'),
('Rio de Janeiro', 'RJ'),
('Rio Grande do Norte', 'RN'),
('Rio Grande do Sul', 'RS'),
('Rondônia', 'RO'),
('Roraima', 'RR'),
('Santa Catarina', 'SC'),
('São Paulo', 'SP'),
('Sergipe', 'SE'),
('Tocantins', 'TO');
  -- -----------------------------------------------------
-- Table `LR_Projeto_Api`.`Cidade`
-- -----------------------------------------------------
CREATE TABLE `Cidade` (
  `id_cid` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `nome_cid` VARCHAR(40) NOT NULL,
  `id_est_fk` INT NOT NULL,
   FOREIGN KEY (`id_est_fk`)
    REFERENCES `Estado` (`id_est`)
);

INSERT INTO `Cidade` (`nome_cid`, `id_est_fk`) VALUES
('Rio Branco', 1),
('Maceió', 2),
('Macapá', 3),
('Manaus', 4),
('Salvador', 5),
('Fortaleza', 6),
('Brasília', 7),
('Vitória', 8),
('Goiânia', 9),
('São Luís', 10),
('Cuiabá', 11),
('Campo Grande', 12),
('Belo Horizonte', 13),
('Belém', 14),
('João Pessoa', 15),
('Curitiba', 16),
('Recife', 17),
('Teresina', 18),
('Rio de Janeiro', 19),
('Natal', 20),
('Porto Alegre', 21),
('Alta Floresta d\'Oeste', 22),
('Alto Alegre dos Parecis', 22),
('Alto Paraíso', 22),
('Alvorada d\'Oeste', 22),
('Ariquemes', 22),
('Buritis', 22),
('Cabixi', 22),
('Cacaulândia', 22),
('Cacoal', 22),
('Campo Novo de Rondônia', 22),
('Candeias do Jamari', 22),
('Castanheiras', 22),
('Cerejeiras', 22),
('Chupinguaia', 22),
('Colorado do Oeste', 22),
('Corumbiara', 22),
('Costa Marques', 22),
('Cujubim', 22),
('Espigão d\'Oeste', 22),
('Governador Jorge Teixeira', 22),
('Guajará-Mirim', 22),
('Itapuã do Oeste', 22),
('Jaru', 22),
('Ji-Paraná', 22),
('Machadinho d\'Oeste', 22),
('Ministro Andreazza', 22),
('Mirante da Serra', 22),
('Monte Negro', 22),
('Nova Brasilândia d\'Oeste', 22),
('Nova Mamoré', 22),
('Nova União', 22),
('Novo Horizonte do Oeste', 22),
('Ouro Preto do Oeste', 22),
('Parecis', 22),
('Pimenta Bueno', 22),
('Pimenteiras do Oeste', 22),
('Porto Velho', 22),
('Presidente Médici', 22),
('Primavera de Rondônia', 22),
('Rio Crespo', 22),
('Rolim de Moura', 22),
('Santa Luzia d\'Oeste', 22),
('São Felipe d\'Oeste', 22),
('São Francisco do Guaporé', 22),
('São Miguel do Guaporé', 22),
('Seringueiras', 22),
('Teixeirópolis', 22),
('Theobroma', 22),
('Urupá', 22),
('Vale do Anari', 22),
('Vale do Paraíso', 22),
('Vilhena', 22),
('Boa Vista', 23),
('Florianópolis', 24),
('São Paulo', 25),
('Aracaju', 26),
('Palmas', 27);
-- -----------------------------------------------------
-- Table `LR_Projeto_Api`.`Endereco`
-- -----------------------------------------------------
CREATE TABLE `Endereco` (
  `id_end` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `rua_end` VARCHAR(200) NOT NULL,
  `bairro_end` VARCHAR(80) NOT NULL,
  `numero_end` INT,
  `complemento_end` VARCHAR(100),
  `referencia_end` VARCHAR(200),
  `cep_end` INT,
  `id_usu_fk` INT NOT NULL,
   FOREIGN KEY (`id_usu_fk`)
    REFERENCES `Usuario` (`id_usu`)
);
-- -----------------------------------------------------
-- Table `LR_Projeto_Api`.`Setup`
-- -----------------------------------------------------
CREATE TABLE `Setup` (
  `id_set` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `unidade_set` INT NOT NULL,
  `nome_set` VARCHAR(85) NOT NULL,
  `valor_set` DOUBLE NOT NULL,
  `descricao_set` TINYTEXT
  );
-- -----------------------------------------------------
-- Table `LR_Projeto_Api`.`Favorito`
-- -----------------------------------------------------
CREATE TABLE `Favorito` (
  `id_fav` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `id_usu_fk` INT NOT NULL,
  `id_set_fk` INT NOT NULL,
  FOREIGN KEY (`id_usu_fk`)
    REFERENCES `Usuario` (`id_usu`),
	FOREIGN KEY (`id_set_fk`)
    REFERENCES `Setup` (`id_set`)
);
-- -----------------------------------------------------
-- Table `LR_Projeto_Api`.`Carrinho`
-- -----------------------------------------------------
CREATE TABLE `Carrinho` (
  `id_car` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `valor_car` DOUBLE NOT NULL,
  `id_usu_fk` INT NOT NULL,
  `id_set_fk` INT NOT NULL,
    FOREIGN KEY (`id_usu_fk`)
    REFERENCES `Usuario` (`id_usu`),
    FOREIGN KEY (`id_set_fk`)
    REFERENCES `Setup` (`id_set`)
    );
-- -----------------------------------------------------
-- Table `LR_Projeto_Api`.`Periferico`
-- -----------------------------------------------------
CREATE TABLE `Periferico` (
  `id_per` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `valor_per` DOUBLE NOT NULL,
  `especificacao_per` TINYTEXT ,
  `link_per` VARCHAR(255) NOT NULL,
  `unidade_per` INT NOT NULL
 );
-- -----------------------------------------------------
-- Table `LR_Projeto_Api`.`Setup_Periferico`
-- -----------------------------------------------------
CREATE TABLE `Setup_Periferico` (
  `id_set_per` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `id_set_fk` INT NOT NULL,
  `id_per_fk` INT NOT NULL,
    FOREIGN KEY (`id_set_fk`)
    REFERENCES `Setup` (`id_set`),
    FOREIGN KEY (`id_per_fk`)
    REFERENCES `Periferico` (`id_per`)
    );
-- -----------------------------------------------------
-- Table `LR_Projeto_Api`.`Computador`
-- -----------------------------------------------------
CREATE TABLE `Computador` (
  `id_com` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `unidade_com` INT NOT NULL,
  `nome_com` VARCHAR(85) NOT NULL,
  `link_com` VARCHAR(255) NOT NULL,
  `valor_com` DOUBLE NOT NULL
  );
-- -----------------------------------------------------
-- Table `LR_Projeto_Api`.`Setup_Computador`
-- -----------------------------------------------------
CREATE TABLE `Setup_Computador` (
  `id_set_com` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `id_set_fk` INT NOT NULL,
  `id_com_fk` INT NOT NULL,
    FOREIGN KEY (`id_set_fk`)
    REFERENCES `Setup` (`id_set`),
    FOREIGN KEY (`id_com_fk`)
    REFERENCES `Computador` (`id_com`)
    );
-- -----------------------------------------------------
-- Table `LR_Projeto_Api`.`Componente`
-- -----------------------------------------------------
CREATE TABLE `Componente` (
  `id_comp` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `especificacao_comp` TINYTEXT,
  `nome_comp` VARCHAR(85) NOT NULL,
  `link_comp` VARCHAR(255) NOT NULL,
  `unidade_comp` INT NOT NULL,
  `valor_comp` DOUBLE NOT NULL
  );
-- -----------------------------------------------------
-- Table `LR_Projeto_Api`.`Computador_Componente`
-- -----------------------------------------------------
CREATE TABLE `Computador_Componente` (
  `id_com_comp` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `quantidade_com_comp` INT NOT NULL,
  `id_com_fk` INT NOT NULL,
  `id_comp_fk` INT NOT NULL,
    FOREIGN KEY (`id_com_fk`)
    REFERENCES `Computador` (`id_com`),
    FOREIGN KEY (`id_comp_fk`)
    REFERENCES `Componente` (`id_comp`)
    );
-- -----------------------------------------------------
-- Table `LR_Projeto_Api`.`Pagamento`
-- -----------------------------------------------------
CREATE TABLE `Pagamento` (
  `id_pag` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `forma_pag` VARCHAR(85) NOT NULL,
  `data_pag` DATE NOT NULL,
  `id_car_fk` INT NOT NULL,
  `id_usu_fk` INT NOT NULL,
    FOREIGN KEY (`id_car_fk` , `id_usu_fk`)
    REFERENCES `Carrinho` (`id_car` , `id_usu_fk`)
);