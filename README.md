# Personal Portfolio Tracker Website

/author: nnthienphuc

## Idea:

- Quản lý (CRUD) các mã theo loại (cổ phiếu, quỹ, trái phiếu, crypto, …)
- Phân tích và tính toán target sell/buy price
- Quản lý (CRUD) transactions (bao gồm cả mua và bán)
- Tạo ra dashboard để tính toán tổng tiền đã bỏ ra, tổng tiền đã thu lại, lãi/lỗ,  các danh mục đầu tư

⇨ Note: Tất cả đều quản lý theo từng user.

---

## Quick design database:

- Investors (id (auto generate), email, hashPassword, fullName, isActive, isDeleted);
- TickerTypes (id (auto generate), typeCode, note, isDeleted);
- Tickers (id (auto generate), ticker, name, investorId, tickerTypeId, investmentPrice, quantity, marketPrice, totalInvestedValue, currentPnLRate, targetBuyPrice (giá mua mong đợi), targetSellPrice (giá bán mong đợi), targetPnLRate, createdAt, updatedAt, note, isDeleted);
- Transactions (id (auto generate), investorId, tickerId, quantity, price, grossAmount, feeRate, fee, netAmount, tradingDate, type, realizedPnL, realizedPnLRate, note, isDeleted),
- AuditLogs (id (auto generate), investorId, action, entityName, entityId, Description, Timestamp, IPAddress, UserAgent);
---

## How to code this project:

- Quantity trong Tickers:
    - Nếu là buy = quantity+ TransactionCreateDTO.quantity
    - Nếu là sell = quantity - TransactionCreateDTO.quantity
- investmentPrice = (quantity * investmentPrice + TransactionCreateDTO.quantity * TransactionCreateDTO.price) / (quantity + TransactionCreateDTO.quantity) (chỉ áp dụng cho buy, còn sell thì không cần tính vì nó không thay đổi).
- currentPnLRate = (marketPrice - investmentPrice) / investmentPrice * 100 (tính toán lại sau mỗi lần buy or update latestMarketPrice).
- targetPnLRate = (targetSellPrice - investmentPrice) / investmentPrice * 100 (tính toán lại sau mỗi lần update buy or update targetSellPrice)
- totalInvestedValue = investmentPrice * quantity (tính lại sau mỗi lần sell or buy).
- targetBuyPrice : Do user tự tính toán và ghi vào, để khi đạt đến giá đó thì sẽ tạo lệnh mua.
- targetSellPrice: Do user tự tính toán và ghi vào, để khi đạt đến giá đó thì sẽ tạo lệnh bán.
- grossAmount= TransactionCreateDTO.quantity * TransactionCreateDTO.price
- fee = grossAmount* feeRate (nếu là buy thì feeRate= 0.03%, nếu là sell thì feeRate= 0.03% + 0.1% = 0.13%).
- netAmount = grossAmount- fee.
- realizedPnL = (price - investmentPrice) * quantity (chỉ áp dụng cho sell để tính lãi/lỗ).
- realizedPnLRate =  (price - investmentPrice) / investmentPrice * 100.