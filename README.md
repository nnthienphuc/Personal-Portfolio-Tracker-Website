# Personal Portfolio Tracker Website

/author: nnthienphuc

## Idea:

- Quản lý (CRUD) các mã theo loại (cổ phiếu, quỹ, trái phiếu, crypto, …)
- Phân tích và tính toán target sell/buy price
- Quản lý (CRUD) transactions (bao gồm cả mua và bán)
- Tạo ra dashboard để tính toán tổng tiền đã bỏ ra, tổng tiền đã thu lại, lãi/lỗ, …
- Thống kê các danh mục đầu tư

⇨ Note: Tất cả đều quản lý theo từng user.

---

## Quick design database:

- Investors (id (auto generate), email, hashPassword, fullName, isActive, isDeleted);
- AssetTypes (id (auto generate), typeCode, typeName, note, isDeleted);
- Assets (id (auto generate), symbol, name, investorId, assetTypeId, avgUnitPrice, currentQuantity, currentMarketPrice, totalInvestedValue, currentPnLRate, targetBuyPrice (giá mua mong đợi), targetSellPrice (giá bán mong đợi), targetPnLRate, createdAt, updatedAt, note, isDeleted);
- Transactions (id (auto generate), assetId, quantity, unitPrice, grossAmount, feeRate, fee, netAmount, createdAt, isBuy(true = buy, false = sell), realizedPnL, realizedPnLRate, note, isDeleted);

---

## How to code this project:

- Quantity trong Assets:
    - Nếu là buy = currentQuantity+ TransactionCreateDTO.quantity
    - Nếu là sell = currentQuantity - TransactionCreateDTO.quantity
- avgUnitPrice = (currentQuantity * avgUnitPrice + TransactionCreateDTO.quantity * TransactionCreateDTO.unitPrice) / (currentQuantity + TransactionCreateDTO.quantity) (chỉ áp dụng cho buy, còn sell thì không cần tính vì nó không thay đổi).
- currentPnLRate = (currentMarketPrice - avgUnitPrice) / avgUnitPrice * 100 (tính toán lại sau mỗi lần buy or update latestMarketPrice).
- targetPnLRate = (targetSellPrice - avgUnitPrice) / avgUnitPrice * 100 (tính toán lại sau mỗi lần update buy or update targetSellPrice)
- totalInvestedValue = avgUnitPrice * currentQuantity (tính lại sau mỗi lần sell or buy).
- targetBuyPrice : Do user tự tính toán và ghi vào, để khi đạt đến giá đó thì sẽ tạo lệnh mua.
- targetSellPrice: Do user tự tính toán và ghi vào, để khi đạt đến giá đó thì sẽ tạo lệnh bán.
- grossAmount= TransactionCreateDTO.quantity * TransactionCreateDTO.unitPrice
- fee = grossAmount* feeRate (nếu là buy thì feeRate= 0.03%, nếu là sell thì feeRate= 0.03% + 0.1% = 0.13%).
- netAmount = grossAmount- fee.
- realizedPnL = (unitPrice - avgUnitPrice) * quantity (chỉ áp dụng cho sell để tính lãi/lỗ).
- realizedPnLRate =  (unitPrice - avgUnitPrice) / avgUnitPrice * 100.