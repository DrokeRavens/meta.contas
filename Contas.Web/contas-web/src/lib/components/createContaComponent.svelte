<script lang="ts">
	import type { CreateContaDto } from '$lib/models/createContaDto';
	import { contasService } from '$lib/services/contasService';
	import Input from './input.svelte';

	export let visible = true;
	export let updatedRequested = () => {};

	let createContaModel: CreateContaDto = {
		dataPagamento: new Date().toDateString(),
		dataVencimento: new Date().toDateString(),
		nome: '',
		valorOriginal: 0.0
	};

	function submitHandler(e: any) {
		e.preventDefault();
		contasService.createConta(createContaModel).finally(() => {
			updatedRequested();
			visible = false;
		});
	}
</script>

{#if visible}
	<div
		class="fixed top-1/2 left-1/2 -translate-y-1/2 -translate-x-1/2 bg-neutral-800 p-4 border border-neutral-400 rounded-lg"
	>
		<form on:submit={submitHandler}>
			<Input type="text" name="Nome" bind:value={createContaModel.nome} />
			<Input type="currency" name="Valor" bind:value={createContaModel.valorOriginal} />
			<Input type="date" name="Data de Pagamento" bind:value={createContaModel.dataPagamento} />
			<Input type="date" name="Data de Vencimento" bind:value={createContaModel.dataVencimento} />
			<button on:click={() => (visible = false)} class=" px-4 py-2 rounded-sm"> Fechar </button>
			<button type="submit" class="bg-green-600 px-4 py-2 rounded-sm"> Salvar </button>
		</form>
	</div>
{/if}
