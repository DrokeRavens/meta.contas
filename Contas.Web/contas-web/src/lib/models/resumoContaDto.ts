export interface ResumoContaDto {
	id: number;
	nome: string;
	valorOriginal: number;
	dataVencimento: string;
	dataPagamento: string;
	diasEmAtraso: number;
	valorCorrigido: number;
}
