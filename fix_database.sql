-- ========================================
-- Database Fix Script for Inventory Issues
-- ========================================

USE `g2db`;

-- 1. Add inv_location column to inventory table if it doesn't exist
ALTER TABLE `inventory` 
ADD COLUMN IF NOT EXISTS `inv_location` varchar(100) NOT NULL DEFAULT 'Main Warehouse' 
COMMENT 'Location/Store' 
AFTER `inv_price`;

-- 2. Add inv_min_level column if it doesn't exist
ALTER TABLE `inventory` 
ADD COLUMN IF NOT EXISTS `inv_min_level` int(11) NOT NULL DEFAULT 20 
COMMENT 'Safety stock minimum threshold' 
AFTER `inv_location`;

-- 3. Add inv_max_level column if it doesn't exist
ALTER TABLE `inventory` 
ADD COLUMN IF NOT EXISTS `inv_max_level` int(11) NOT NULL DEFAULT 200 
COMMENT 'Maximum stock capacity' 
AFTER `inv_min_level`;

-- 4. Update existing inventory items with location
UPDATE `inventory` SET `inv_location` = 'Main Warehouse' WHERE `inv_location` IS NULL OR `inv_location` = '';

-- 5. Create stock_movements table if it doesn't exist
CREATE TABLE IF NOT EXISTS `stock_movements` (
  `movement_id` int(11) NOT NULL AUTO_INCREMENT,
  `inv_product_id` varchar(50) NOT NULL,
  `movement_type` varchar(20) NOT NULL COMMENT 'Inbound or Outbound',
  `quantity` int(11) NOT NULL,
  `movement_date` datetime DEFAULT current_timestamp(),
  `location` varchar(100) DEFAULT 'Main Warehouse',
  `reference` varchar(100) DEFAULT NULL COMMENT 'Reference order/batch ID',
  `operator` varchar(100) DEFAULT NULL COMMENT 'Staff who performed the movement',
  `notes` text DEFAULT NULL,
  PRIMARY KEY (`movement_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- 6. Create restock_requests table if it doesn't exist
CREATE TABLE IF NOT EXISTS `restock_requests` (
  `restock_id` int(11) NOT NULL AUTO_INCREMENT,
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
  `notes` text DEFAULT NULL,
  PRIMARY KEY (`restock_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- 7. Verify and update inventory with sample locations
UPDATE `inventory` SET `inv_location` = 'Main Warehouse' WHERE `inv_product_id` IN ('PROD001', 'PROD002', 'PROD005', 'PROD006', 'PROD008', 'PROD009');
UPDATE `inventory` SET `inv_location` = 'Kowloon Bay Retail Shop' WHERE `inv_product_id` IN ('PROD003', 'PROD004', 'PROD007');

-- 8. Set default min/max levels if not set
UPDATE `inventory` SET `inv_min_level` = 20 WHERE `inv_min_level` = 0 OR `inv_min_level` IS NULL;
UPDATE `inventory` SET `inv_max_level` = 200 WHERE `inv_max_level` = 0 OR `inv_max_level` IS NULL;

-- ========================================
-- Fix Complete
-- ========================================
SELECT 'Database fix completed successfully!' AS message;
