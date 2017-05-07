-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema PiggyMetrics
-- -----------------------------------------------------
-- PiggyMetrics ���ݿ�

-- -----------------------------------------------------
-- Schema PiggyMetrics
--
-- PiggyMetrics ���ݿ�
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `PiggyMetrics` DEFAULT CHARACTER SET utf8 ;
USE `PiggyMetrics` ;

-- -----------------------------------------------------
-- Table `PiggyMetrics`.`user_auth`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PiggyMetrics`.`user_auth` (
  `account` VARCHAR(50) NOT NULL COMMENT '�û��˺�',
  `password` VARCHAR(50) NOT NULL COMMENT '����',
  `create_time` DATETIME NOT NULL COMMENT '����ʱ��',
  `last_sen_time` DATETIME NOT NULL COMMENT '���һ�β鿴ʱ��',
  PRIMARY KEY (`account`),
  UNIQUE INDEX `account_UNIQUE` (`account` ASC))
ENGINE = MyISAM
COMMENT = '�û�������Ϣ��';


-- -----------------------------------------------------
-- Table `PiggyMetrics`.`user_income`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PiggyMetrics`.`user_income` (
  `idx` INT NOT NULL AUTO_INCREMENT COMMENT '��������',
  `account` VARCHAR(50) NOT NULL COMMENT '�˺�',
  `title` VARCHAR(50) NOT NULL COMMENT '����',
  `amount` DECIMAL(16,2) NOT NULL DEFAULT 0 COMMENT '���',
  `currency` TINYINT NOT NULL DEFAULT 1 COMMENT '�������� 1=USD 2= RBM 3=EUR',
  `time_period` TINYINT NOT NULL DEFAULT 3 COMMENT '����  1=YEAR,2= QUARTER,3= MONTH,4= DAY,5= HOUR',
  `icon` VARCHAR(50) NOT NULL COMMENT 'ͼ��',
  PRIMARY KEY (`idx`))
ENGINE = MyISAM;


-- -----------------------------------------------------
-- Table `PiggyMetrics`.`user_expense`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PiggyMetrics`.`user_expense` (
  `idx` INT NOT NULL AUTO_INCREMENT COMMENT '��������',
  `account` VARCHAR(50) NOT NULL COMMENT '�˺�',
  `title` VARCHAR(50) NOT NULL COMMENT '����',
  `amount` DECIMAL(16,2) NOT NULL DEFAULT 0 COMMENT '���',
  `currency` TINYINT NOT NULL DEFAULT 1 COMMENT '�������� 1=USD 2= RBM 3=EUR',
  `time_period` TINYINT NOT NULL DEFAULT 3 COMMENT '����  1=YEAR,2= QUARTER,3= MONTH,4= DAY,5= HOUR',
  `icon` VARCHAR(50) NOT NULL COMMENT 'ͼ��',
  PRIMARY KEY (`idx`))
ENGINE = MyISAM;


-- -----------------------------------------------------
-- Table `PiggyMetrics`.`user_saving`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PiggyMetrics`.`user_saving` (
  `account` VARCHAR(50) NOT NULL,
  `amount` DECIMAL(16,2) NOT NULL DEFAULT 0,
  `currency` TINYINT NOT NULL DEFAULT 1 COMMENT '�������� 1=USD 2= RBM 3=EUR',
  `interest` DECIMAL(8,2) NOT NULL DEFAULT 0 COMMENT '��Ϣ',
  `deposit` TINYINT NOT NULL DEFAULT 0 COMMENT '�Ƿ���',
  `capitalization` TINYINT NOT NULL DEFAULT 0 COMMENT '�Ƿ�������',
  PRIMARY KEY (`account`))
ENGINE = MyISAM;


-- -----------------------------------------------------
-- Table `PiggyMetrics`.`user_info`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PiggyMetrics`.`user_info` (
  `account` VARCHAR(50) NOT NULL,
  `last_seen_time` DATETIME NOT NULL,
  `create_time` DATETIME NOT NULL,
  PRIMARY KEY (`account`))
ENGINE = MyISAM;


-- -----------------------------------------------------
-- Table `PiggyMetrics`.`data_point`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PiggyMetrics`.`data_point` (
  `point_id` INT NOT NULL AUTO_INCREMENT COMMENT '������������',
  `account` VARCHAR(50) NOT NULL COMMENT '�˺�',
  `point_date` DATETIME NOT NULL COMMENT '��¼����',
  PRIMARY KEY (`point_id`))
ENGINE = MyISAM;


-- -----------------------------------------------------
-- Table `PiggyMetrics`.`data_point_income`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PiggyMetrics`.`data_point_income` (
  `idx` INT NOT NULL AUTO_INCREMENT,
  `point_idx` INT NOT NULL,
  `title` VARCHAR(50) NOT NULL COMMENT '����',
  `amount` DECIMAL(16,2) NOT NULL DEFAULT 0 COMMENT '���',
  PRIMARY KEY (`idx`))
ENGINE = MyISAM;


-- -----------------------------------------------------
-- Table `PiggyMetrics`.`data_point_expense`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PiggyMetrics`.`data_point_expense` (
  `idx` INT NOT NULL AUTO_INCREMENT,
  `point_id` INT NOT NULL,
  `title` VARCHAR(50) NOT NULL COMMENT '����',
  `amount` DECIMAL(16,2) NOT NULL DEFAULT 0 COMMENT '���',
  PRIMARY KEY (`idx`))
ENGINE = MyISAM;


-- -----------------------------------------------------
-- Table `PiggyMetrics`.`data_point_stat`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PiggyMetrics`.`data_point_stat` (
  `idx` INT NOT NULL AUTO_INCREMENT,
  `point_id` INT NOT NULL,
  `stat_metric` TINYINT NOT NULL DEFAULT 1 COMMENT 'ͳ������  1= income 2 expense 3 saving',
  `amount` DECIMAL(16,2) NOT NULL DEFAULT 0,
  PRIMARY KEY (`idx`))
ENGINE = MyISAM;


-- -----------------------------------------------------
-- Table `PiggyMetrics`.`data_point_rate`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PiggyMetrics`.`data_point_rate` (
  `idx` INT NOT NULL AUTO_INCREMENT,
  `point_id` INT NOT NULL,
  `currency` TINYINT NOT NULL DEFAULT 1 COMMENT '�������� 1=USD 2= RBM 3=EUR',
  `rate` DECIMAL(6,2) NOT NULL DEFAULT 1 COMMENT '���ʣ�ת������Ԫ',
  PRIMARY KEY (`idx`))
ENGINE = MyISAM;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
