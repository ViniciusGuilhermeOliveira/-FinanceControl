CREATE TABLE cartoes (
    car_id_car INT PRIMARY KEY AUTO_INCREMENT,  --id_cartao 
    car_nam_car VARCHAR(50) NOT NULL,   --nome_cartao 
    car_dia_fec INT,  --dia_fechamento
    car_dia_ven INT NOT NULL  --dia_vencimento
    car_dia_pag INT NOT NULL -- dia de pagamento do cartão
);