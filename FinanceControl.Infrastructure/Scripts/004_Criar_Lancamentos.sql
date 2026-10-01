CREATE TABLE lancamentos (
    lan_id_lan INT PRIMARY KEY AUTO_INCREMENT,  --id_lancamento
    lan_des_lan VARCHAR(100) NOT NULL,          --descricao
    lan_val_lan DECIMAL(10, 2) NOT NULL,        --valor
    lan_tip_lan ENUM('ENTRADA', 'CONTA_FIXA', 'FATURA_CARTAO', 'DESPESA_AVULSA') NOT NULL,--tipo_lancamento
    lan_dat_com DATE NOT NULL,                  --data_competencia
    lan_dat_pag_rec DATE NOT NULL,              --data_pagamento_recebimento
    lan_car_id_car INT NULL,                    --id_cartao
    lan_par_atu INT NULL,                       --parcela_atual
    lan_par_tot INT NULL,                       --total_parcelas
    lan_sta_efe BOOLEAN DEFAULT FALSE,          --status_efetivado
    
    FOREIGN KEY (lan_car_id_car) REFERENCES car(car_id_car)
);
