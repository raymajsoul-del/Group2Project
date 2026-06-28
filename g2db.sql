-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- 主機： 127.0.0.1
-- 產生時間： 2026-06-19 18:57:31
-- 伺服器版本： 10.4.32-MariaDB
-- PHP 版本： 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
 
--
-- Create database and select it
--
CREATE DATABASE IF NOT EXISTS `g2db`
  DEFAULT CHARACTER SET utf8mb4
  COLLATE utf8mb4_unicode_ci;
USE `g2db`;

--
-- 資料庫： `g2db`
--

-- --------------------------------------------------------

--
-- 資料表結構 `after_sales_requests`
--

CREATE TABLE `after_sales_requests` (
  `request_id` int(11) NOT NULL,
  `customer_id` varchar(50) DEFAULT NULL,
  `order_id` varchar(50) DEFAULT NULL,
  `issue_description` text DEFAULT NULL,
  `request_date` datetime DEFAULT current_timestamp(),
  `status` varchar(50) DEFAULT 'Under Review'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 資料表結構 `customers`
--

CREATE TABLE `customers` (
  `customer_id` varchar(50) NOT NULL,
  `customer_name` varchar(100) DEFAULT NULL,
  `contact_number` varchar(50) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `customers`
--

INSERT INTO `customers` (`customer_id`, `customer_name`, `contact_number`, `address`, `email`) VALUES
('CUST001', 'J', '91234567', 'Hong Kong Institute of Vocational Education (Sha Tin)', 'j@example.com'),
('CUST002', 'W', '98765432', 'Yuen Wo Rd, 21, Sha Tin, Hong Kong', 'w@example.com');

-- --------------------------------------------------------

--
-- 資料表結構 `deliveries`
--

CREATE TABLE `deliveries` (
  `delivery_id` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `driver_id` varchar(50) DEFAULT 'Unassigned',
  `vehicle_type` varchar(50) DEFAULT 'Unassigned',
  `delivery_date` date DEFAULT NULL,
  `delivery_status` varchar(50) DEFAULT 'Pending Dispatch',
  `created_at` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 資料表結構 `drivers`
--

CREATE TABLE `drivers` (
  `driver_id` varchar(50) NOT NULL,
  `driver_name` varchar(100) DEFAULT NULL,
  `license_type` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `drivers`
--

INSERT INTO `drivers` (`driver_id`, `driver_name`, `license_type`) VALUES
('D001', 'Chopper', 'LGV'),
('D002', 'Tom', 'HGV'),
('D003', 'Lam', 'LGV'),
('D004', 'Ken', 'LGV'),
('D005', '259', 'HGV'),
('D006', '910', 'LGV'),
('D007', 'Ray', 'HGV'),
('D008', 'Donk', 'LGV'),
('D009', 'Decade', 'LGV'),
('D010', 'Zio', 'HGV'),
('D011', 'Lo', 'LGV'),
('D012', '666', 'HGV'),
('D013', 'Shiro', 'LGV'),
('D014', 'NG', 'LGV'),
('D015', 'NaiLong', 'HGV'),
('D016', 'Ropz', 'LGV'),
('D017', 'Apex', 'HGV'),
('D018', 'Niko', 'LGV'),
('D019', 'Zwyoo', 'LGV'),
('D020', 'Monsey', 'HGV');

-- --------------------------------------------------------

--
-- 資料表結構 `inventory`
--

CREATE TABLE `inventory` (
  `inv_product_id` varchar(50) NOT NULL,
  `inv_product_name` varchar(100) NOT NULL COMMENT 'product name',
  `inv_category` varchar(50) NOT NULL COMMENT 'Classification',
  `inv_stock_quantity` int(11) NOT NULL COMMENT 'now QTY',
  `inv_price` decimal(10,2) NOT NULL COMMENT 'Price (supports two decimal places)',
  `inv_location` varchar(100) NOT NULL DEFAULT 'Main Warehouse' COMMENT 'Location/Store',
  `inv_min_level` int(11) NOT NULL DEFAULT 20 COMMENT 'Safety stock minimum threshold',
  `inv_max_level` int(11) NOT NULL DEFAULT 200 COMMENT 'Maximum stock capacity'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `inventory`
--

INSERT INTO `inventory` (`inv_product_id`, `inv_product_name`, `inv_category`, `inv_stock_quantity`, `inv_price`, `inv_location`, `inv_min_level`, `inv_max_level`) VALUES
('PROD001', 'Nordic Fabric Sofa', 'Living Room', 50, 3500.00, 'Main Warehouse', 15, 80),
('PROD002', 'Modern Oak Dining Table', 'Dining Room', 30, 4200.00, 'Main Warehouse', 10, 50),
('PROD003', 'Ergonomic Office Chair', 'Office', 100, 1250.00, 'Kowloon Bay Retail Shop', 30, 150),
('PROD004', 'Minimalist TV Cabinet', 'Living Room', 40, 2800.00, 'Kowloon Bay Retail Shop', 12, 60),
('PROD005', 'King Size Bed Frame', 'Bedroom', 20, 5600.00, 'Main Warehouse', 8, 35),
('PROD006', 'Wooden Bookshelf', 'Study', 60, 1800.00, 'Main Warehouse', 20, 100),
('PROD007', 'Leather Lounge Chair', 'Living Room', 35, 4500.00, 'Kowloon Bay Retail Shop', 10, 50),
('PROD008', 'Glass Coffee Table', 'Living Room', 45, 1600.00, 'Main Warehouse', 15, 70),
('PROD009', 'Bedside Nightstand', 'Bedroom', 80, 850.00, 'Main Warehouse', 25, 120);

-- --------------------------------------------------------

--
-- 資料表結構 `stock_movements`
--
-- Tracks all inbound and outbound inventory movements for audit trail
--

CREATE TABLE `stock_movements` (
  `movement_id` int(11) NOT NULL,
  `inv_product_id` varchar(50) NOT NULL,
  `movement_type` varchar(20) NOT NULL COMMENT 'Inbound or Outbound',
  `quantity` int(11) NOT NULL,
  `movement_date` datetime DEFAULT current_timestamp(),
  `location` varchar(100) DEFAULT 'Main Warehouse',
  `reference` varchar(100) DEFAULT NULL COMMENT 'Reference order/batch ID',
  `operator` varchar(100) DEFAULT NULL COMMENT 'Staff who performed the movement',
  `notes` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 資料表結構 `restock_requests`
--
-- Multi-level approval workflow for automated restocking
--

CREATE TABLE `restock_requests` (
  `restock_id` int(11) NOT NULL,
  `inv_product_id` varchar(50) NOT NULL,
  `current_stock` int(11) NOT NULL,
  `min_level` int(11) NOT NULL,
  `max_level` int(11) NOT NULL,
  `suggested_qty` int(11) NOT NULL COMMENT 'Auto-calculated: max_level - current_stock',
  `location` varchar(100) NOT NULL,
  `request_date` datetime DEFAULT current_timestamp(),
  `approval_status` varchar(50) DEFAULT 'Pending Shop Manager' COMMENT 'Multi-level approval status',
  `shop_manager_approval` varchar(20) DEFAULT 'Pending' COMMENT 'Shop Manager approval',
  `shop_manager_date` datetime DEFAULT NULL,
  `inventory_manager_approval` varchar(20) DEFAULT 'Pending' COMMENT 'Inventory Manager approval',
  `inventory_manager_date` datetime DEFAULT NULL,
  `purchase_dept_approval` varchar(20) DEFAULT 'Pending' COMMENT 'Purchase Department approval',
  `purchase_dept_date` datetime DEFAULT NULL,
  `requestor` varchar(100) DEFAULT NULL COMMENT 'Staff who requested (or "SYSTEM" for auto)',
  `notes` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 資料表結構 `material_requests`
--

CREATE TABLE `material_requests` (
  `request_id` int(11) NOT NULL,
  `material_code` varchar(50) NOT NULL,
  `quantity_required` int(11) NOT NULL,
  `urgency_level` varchar(20) NOT NULL,
  `request_status` varchar(50) DEFAULT 'Pending Approval',
  `request_date` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 資料表結構 `orders`
--

CREATE TABLE `orders` (
  `order_id` int(11) NOT NULL COMMENT 'order id',
  `order_customer_name` varchar(100) NOT NULL COMMENT 'customer name',
  `order_customer_contact` varchar(100) DEFAULT NULL,
  `order_date` datetime DEFAULT NULL COMMENT 'date',
  `order_status` varchar(20) DEFAULT 'Pending' COMMENT 'state',
  `customer_id` varchar(50) DEFAULT NULL,
  `total_amount` decimal(10,2) DEFAULT NULL,
  `status` varchar(50) DEFAULT 'Pending',
  `delivery_date` date DEFAULT NULL,
  `delivery_staff` varchar(100) DEFAULT 'Pending Assignment'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 資料表結構 `order_items`
--

CREATE TABLE `order_items` (
  `ot_items_id` int(11) NOT NULL,
  `ot_order_id` int(11) NOT NULL,
  `ot_product_id` varchar(50) NOT NULL,
  `ot_quantity` int(11) NOT NULL,
  `ot_unit_price` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 資料表結構 `procurement`
--

CREATE TABLE `procurement` (
  `proc_id` int(11) NOT NULL,
  `proc_supplier` varchar(100) NOT NULL,
  `proc_item` varchar(100) NOT NULL,
  `proc_qty` int(11) NOT NULL,
  `proc_cost` decimal(10,2) NOT NULL,
  `proc_status` varchar(20) DEFAULT 'Pending',
  `proc_date` datetime DEFAULT current_timestamp(),
  `proc_notes` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 資料表結構 `production_tasks`
--

CREATE TABLE `production_tasks` (
  `task_id` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `product_name` varchar(100) NOT NULL,
  `quantity` int(11) NOT NULL,
  `task_status` varchar(50) DEFAULT 'Pending',
  `start_date` datetime DEFAULT current_timestamp(),
  `completion_date` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 資料表結構 `products_master`
--

CREATE TABLE `products_master` (
  `item_id` varchar(50) NOT NULL,
  `item_name` varchar(100) DEFAULT NULL,
  `category` varchar(50) DEFAULT NULL,
  `unit_price` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `products_master`
--

INSERT INTO `products_master` (`item_id`, `item_name`, `category`, `unit_price`) VALUES
('PROD001', 'Nordic Fabric Sofa', 'Living Room', 3500.00),
('PROD002', 'Modern Oak Dining Table', 'Dining Room', 4200.00),
('PROD003', 'Ergonomic Office Chair', 'Office', 1250.00),
('PROD004', 'Minimalist TV Cabinet', 'Living Room', 2800.00),
('PROD005', 'King Size Bed Frame', 'Bedroom', 5600.00),
('PROD006', 'Wooden Bookshelf', 'Study', 1800.00),
('PROD007', 'Leather Lounge Chair', 'Living Room', 4500.00),
('PROD008', 'Glass Coffee Table', 'Living Room', 1600.00),
('PROD009', 'Bedside Nightstand', 'Bedroom', 850.00);

-- --------------------------------------------------------

--
-- 資料表結構 `service_cases`
--

CREATE TABLE `service_cases` (
  `case_id` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `customer_id` varchar(50) DEFAULT NULL,
  `case_type` varchar(100) NOT NULL,
  `description` text DEFAULT NULL,
  `case_status` varchar(50) DEFAULT 'Pending',
  `technician_id` varchar(50) DEFAULT 'Unassigned',
  `created_at` datetime DEFAULT current_timestamp(),
  `case_description` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 資料表結構 `staff`
--

CREATE TABLE `staff` (
  `staff_id` varchar(20) NOT NULL COMMENT 'Login Account ID',
  `password` varchar(50) NOT NULL COMMENT 'Login Password',
  `staff_name` varchar(50) NOT NULL COMMENT 'Staff Name',
  `email` varchar(100) DEFAULT NULL COMMENT 'Email Address for password reset',
  `role` varchar(50) NOT NULL COMMENT 'Job Role',
  `status` varchar(20) DEFAULT 'Active' COMMENT 'Account Status'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `staff`
--

INSERT INTO `staff` (`staff_id`, `password`, `staff_name`, `email`, `role`, `status`) VALUES
('admin', '123456', 'System Administrator', 'admin@betterlimited.com', 'Manager', 'Active'),
('cs01', '123456', 'Master Yi (Customer Service)', 'cs01@betterlimited.com', 'AfterSales', 'Active'),
('emp01', '250437908', 'RayNiNE', 'emp01@betterlimited.com', 'Staff', 'Active'),
('fin01', '123456', 'NGD (Finance Dept)', 'fin01@betterlimited.com', 'Finance', 'Active'),
('inv01', '123456', 'Marco (Warehouse)', 'inv01@betterlimited.com', 'Inventory', 'Active'),
('log01', '123456', 'Danial (Logistics)', 'log01@betterlimited.com', 'Logistics', 'Active'),
('prod01', '123456', 'Jimmy (Factory)', 'prod01@betterlimited.com', 'Production', 'Active'),
('sales01', '123456', 'R9(Sales Dept)', 'sales01@betterlimited.com', 'Sales', 'Active');

-- --------------------------------------------------------

--
-- 資料表結構 `password_reset_tokens`
--

CREATE TABLE `password_reset_tokens` (
  `token` varchar(100) NOT NULL,
  `staff_id` varchar(20) NOT NULL,
  `expires_at` datetime NOT NULL,
  `is_used` tinyint(1) DEFAULT 0,
  `created_at` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 資料表索引 `password_reset_tokens`
--

ALTER TABLE `password_reset_tokens`
  ADD PRIMARY KEY (`token`);

-- --------------------------------------------------------

--
-- 資料表結構 `customer_password_reset_tokens`
--

CREATE TABLE `customer_password_reset_tokens` (
  `token` varchar(255) NOT NULL,
  `customer_id` varchar(50) NOT NULL,
  `expires_at` datetime DEFAULT NULL,
  `is_used` tinyint(1) DEFAULT 0,
  `created_at` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 資料表索引 `customer_password_reset_tokens`
--

ALTER TABLE `customer_password_reset_tokens`
  ADD PRIMARY KEY (`token`);

-- --------------------------------------------------------

--
-- 資料表結構 `suppliers`
--

CREATE TABLE `suppliers` (
  `supplier_id` varchar(20) NOT NULL,
  `supplier_name` varchar(100) NOT NULL,
  `contact_person` varchar(50) DEFAULT NULL,
  `contact_number` varchar(50) DEFAULT NULL,
  `status` varchar(20) DEFAULT 'Active'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `suppliers`
--

INSERT INTO `suppliers` (`supplier_id`, `supplier_name`, `contact_person`, `contact_number`, `status`) VALUES
('S001', 'Timberland Woodworks', 'John Smith', '91234567', 'Active'),
('S002', 'Premium Leather Co.', 'Mary Jane', '98765432', 'Active'),
('S003', 'LimbusCompany', 'Mr.Tom', '57865592', 'Active');

--
-- 已傾印資料表的索引
--

--
-- 資料表索引 `after_sales_requests`
--
ALTER TABLE `after_sales_requests`
  ADD PRIMARY KEY (`request_id`);

--
-- 資料表索引 `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`customer_id`);

--
-- 資料表索引 `deliveries`
--
ALTER TABLE `deliveries`
  ADD PRIMARY KEY (`delivery_id`);

--
-- 資料表索引 `drivers`
--
ALTER TABLE `drivers`
  ADD PRIMARY KEY (`driver_id`);

--
-- 資料表索引 `inventory`
--
ALTER TABLE `inventory`
  ADD PRIMARY KEY (`inv_product_id`);

--
-- 資料表索引 `stock_movements`
--
ALTER TABLE `stock_movements`
  ADD PRIMARY KEY (`movement_id`);

--
-- 資料表索引 `restock_requests`
--
ALTER TABLE `restock_requests`
  ADD PRIMARY KEY (`restock_id`);

--
-- 資料表索引 `material_requests`
--
ALTER TABLE `material_requests`
  ADD PRIMARY KEY (`request_id`);

--
-- 資料表索引 `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`order_id`);

--
-- 資料表索引 `order_items`
--
ALTER TABLE `order_items`
  ADD PRIMARY KEY (`ot_items_id`);

--
-- 資料表索引 `procurement`
--
ALTER TABLE `procurement`
  ADD PRIMARY KEY (`proc_id`);

--
-- 資料表索引 `production_tasks`
--
ALTER TABLE `production_tasks`
  ADD PRIMARY KEY (`task_id`);

--
-- 資料表索引 `products_master`
--
ALTER TABLE `products_master`
  ADD PRIMARY KEY (`item_id`);

--
-- 資料表索引 `service_cases`
--
ALTER TABLE `service_cases`
  ADD PRIMARY KEY (`case_id`);

--
-- 資料表索引 `staff`
--
ALTER TABLE `staff`
  ADD PRIMARY KEY (`staff_id`);

--
-- 資料表索引 `suppliers`
--
ALTER TABLE `suppliers`
  ADD PRIMARY KEY (`supplier_id`);

--
-- 在傾印的資料表使用自動遞增(AUTO_INCREMENT)
--

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `after_sales_requests`
--
ALTER TABLE `after_sales_requests`
  MODIFY `request_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `deliveries`
--
ALTER TABLE `deliveries`
  MODIFY `delivery_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `material_requests`
--
ALTER TABLE `material_requests`
  MODIFY `request_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `stock_movements`
--
ALTER TABLE `stock_movements`
  MODIFY `movement_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `restock_requests`
--
ALTER TABLE `restock_requests`
  MODIFY `restock_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `orders`
--
ALTER TABLE `orders`
  MODIFY `order_id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'order id';

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `order_items`
--
ALTER TABLE `order_items`
  MODIFY `ot_items_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `procurement`
--
ALTER TABLE `procurement`
  MODIFY `proc_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `production_tasks`
--
ALTER TABLE `production_tasks`
  MODIFY `task_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `service_cases`
--
ALTER TABLE `service_cases`
  MODIFY `case_id` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
