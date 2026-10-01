CREATE VIEW resumo_quinzenal AS
SELECT 
    DATE_FORMAT(data_competencia, '%Y-%m') AS mes_referencia,
    
    -- CÁLCULO DA 1ª QUINZENA (Dias 01 a 15)
    SUM(CASE WHEN tipo_lancamento = 'ENTRADA' AND DAY(data_pagamento_recebimento) <= 15 THEN valor ELSE 0 END) -
    SUM(CASE WHEN tipo_lancamento != 'ENTRADA' AND DAY(data_pagamento_recebimento) <= 15 THEN valor ELSE 0 END) 
    AS sobra_dia_15,

    -- CÁLCULO DA 2ª QUINZENA (Dias 16 a 31)
    SUM(CASE WHEN tipo_lancamento = 'ENTRADA' AND DAY(data_pagamento_recebimento) >= 16 THEN valor ELSE 0 END) -
    SUM(CASE WHEN tipo_lancamento != 'ENTRADA' AND DAY(data_pagamento_recebimento) >= 16 THEN valor ELSE 0 END) 
    AS sobra_dia_30

FROM lancamentos
GROUP BY mes_referencia;