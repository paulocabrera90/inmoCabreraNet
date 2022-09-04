-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 04-09-2022 a las 19:05:29
-- Versión del servidor: 10.4.22-MariaDB
-- Versión de PHP: 8.0.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `inmocabrera`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inquilino`
--

CREATE TABLE `inquilino` (
  `inq_id` int(11) NOT NULL,
  `inq_dni` varchar(16) COLLATE utf8_spanish_ci NOT NULL,
  `inq_nombre` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `inq_fechaNac` date NOT NULL,
  `inq_domicilioTrabajo` varchar(200) COLLATE utf8_spanish_ci NOT NULL,
  `inq_telef` varchar(30) COLLATE utf8_spanish_ci NOT NULL,
  `inq_email` varchar(56) COLLATE utf8_spanish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `inquilino`
--

INSERT INTO `inquilino` (`inq_id`, `inq_dni`, `inq_nombre`, `inq_fechaNac`, `inq_domicilioTrabajo`, `inq_telef`, `inq_email`) VALUES
(6, '37548859', 'Gonzalo David', '2021-08-11', 'asdsad', '26647858965', 'gonzalo@correo.com'),
(7, '32544785', 'Federico Marzano', '2021-04-24', 'Barrio el Hornero', '26647858966', 'fede@corre3o.com'),
(9, '36855898', 'Roberto Pintos', '2021-09-24', 'Belgrano 159', '26641515215', 'mario@corre3o.com'),
(10, '34558588', 'Nicolas Perez', '2021-08-11', 'Potrero de los funes', '26441114445', 'nicolas@correo.com'),
(11, '13321342', 'Mario Raúl wAvaca', '2021-09-24', 'Juana Koslay', '26641515215', 'mario@corre3o.com');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `propietario`
--

CREATE TABLE `propietario` (
  `pro_id` int(11) NOT NULL,
  `pro_dni` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `pro_nombre` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `pro_fechanac` datetime DEFAULT NULL,
  `pro_direc` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `pro_telef` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `pro_email` varchar(45) COLLATE utf8_bin DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Volcado de datos para la tabla `propietario`
--

INSERT INTO `propietario` (`pro_id`, `pro_dni`, `pro_nombre`, `pro_fechanac`, `pro_direc`, `pro_telef`, `pro_email`) VALUES
(1, '35104957', 'Paulo Cabreras', '1990-01-31 00:00:00', 'Fray', '123123123', 'paulocabrera90@gmail.com'),
(2, '29333567', 'Maria Alcaraz', '1984-08-16 00:00:00', 'Barrio Jardin', '2664151516', 'maria@correo.com'),
(3, '19666327', 'Carlos Villegas', '1975-09-09 00:00:00', 'Aeropuerto', '45342542325', 'carlos@mail.com'),
(4, '41922311', 'Gastón Sosa', '2021-09-09 00:00:00', 'Edesal', '266543654', 'gaston@correo.com'),
(5, '31123123', 'Maria Fernanda Ochoa', '2021-08-17 00:00:00', 'Lamadrid', '2334235345', 'fer@correo.com');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `inquilino`
--
ALTER TABLE `inquilino`
  ADD PRIMARY KEY (`inq_id`),
  ADD KEY `inq_fechaNac` (`inq_fechaNac`);

--
-- Indices de la tabla `propietario`
--
ALTER TABLE `propietario`
  ADD PRIMARY KEY (`pro_id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `inquilino`
--
ALTER TABLE `inquilino`
  MODIFY `inq_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT de la tabla `propietario`
--
ALTER TABLE `propietario`
  MODIFY `pro_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
