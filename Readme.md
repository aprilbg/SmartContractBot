#### 마이그레이션 생성 및 적용
```
dotnet ef migrations add InitialCreate --context Transaction_DB_eth --output-dir migrations_ETH/hash
dotnet ef database update --context Transaction_DB_eth

dotnet ef migrations add InitialCreate --context Transaction_DB_matic --output-dir migrations_Matic/hash
dotnet ef database update --context Transaction_DB_matic

dotnet ef migrations add InitialCreate --context Transaction_DB_klaytn --output-dir migrations_klaytn/hash
dotnet ef database update --context Transaction_DB_klaytn

dotnet ef migrations add InitialCreate --context Transaction_DB_nft --output-dir migrations_nft/hash
dotnet ef database update --context Transaction_DB_nft
```