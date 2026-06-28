USE `g2db`;

-- Create delivery_requests table (for delivery info from POS orders)
CREATE TABLE IF NOT EXISTS `delivery_requests` (
  `request_id` int(11) NOT NULL AUTO_INCREMENT,
  `order_id` int(11) NOT NULL,
  `delivery_address` varchar(255) DEFAULT NULL,
  `contact_phone` varchar(50) DEFAULT NULL,
  `delivery_date` date DEFAULT NULL,
  `installation_time` varchar(100) DEFAULT NULL,
  `status` varchar(50) DEFAULT 'Scheduled',
  `created_at` datetime DEFAULT current_timestamp(),
  PRIMARY KEY (`request_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Create defect_reports table (for defect reporting from POS)
CREATE TABLE IF NOT EXISTS `defect_reports` (
  `report_id` int(11) NOT NULL AUTO_INCREMENT,
  `product_id` varchar(50) DEFAULT NULL,
  `product_name` varchar(100) DEFAULT NULL,
  `defect_description` text DEFAULT NULL,
  `reported_by` varchar(100) DEFAULT NULL,
  `report_date` datetime DEFAULT current_timestamp(),
  `status` varchar(50) DEFAULT 'Pending Review',
  PRIMARY KEY (`report_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Add missing columns to orders table if they don't exist (for POS checkout functionality)
ALTER TABLE `orders` 
ADD COLUMN IF NOT EXISTS `order_total_amount` decimal(10,2) DEFAULT NULL AFTER `total_amount`,
ADD COLUMN IF NOT EXISTS `order_discount` decimal(10,2) DEFAULT NULL AFTER `order_total_amount`,
ADD COLUMN IF NOT EXISTS `order_payment_method` varchar(50) DEFAULT NULL AFTER `order_discount`;

SELECT 'Missing tables added successfully!' AS message;
