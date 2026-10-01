CREATE TABLE cartoes (
    car_id_car INTEGER PRIMARY KEY AUTOINCREMENT,  --id_cartao 
    car_nam_car VARCHAR(50) NOT NULL,   --nome_cartao 
    car_dia_fec INTEGER,  --dia_fechamento
    car_dia_ven INTEGER NOT NULL,  --dia_vencimento
    car_dia_pag INTEGER NOT NULL -- dia de pagamento do cartão
);