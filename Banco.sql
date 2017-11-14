CREATE TABLE bdchamado.dbo.chamado (
	idChamado uniqueidentifier NOT NULL,
	idProduto uniqueidentifier NOT NULL,
	descricao varchar(500),
	status smallint NOT NULL,
	motivo varchar(500),
	dataCriacao datetime NOT NULL,
	dataEdicao datetime,
	quantidade int NOT NULL
) go
CREATE INDEX chamado_idProduto_IDX ON bdchamado.dbo.chamado (idProduto,idChamado) go;
