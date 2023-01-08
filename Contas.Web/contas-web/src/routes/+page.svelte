<script lang="ts">
	import CreateContaComponent from '$lib/components/createContaComponent.svelte';
	import type { ResumoContaDto } from '$lib/models/resumoContaDto';
	import { contasService } from '$lib/services/contasService';
	import { onMount } from 'svelte';

	let contas: ResumoContaDto[] = [];
	let createContaVisible = false;

	function updateContas() {
		contasService.getContas().then((response) => {
			contas = response?.data;
		});
	}

	onMount(() => {
		updateContas();
		return () => {
			contas = [];
		};
	});
</script>

<svelte:head>
	<title>Contas</title>
</svelte:head>

<div>
	<div class="h-screen w-screen flex items-center justify-center flex-col gap-4">
		<div class="h-1/2 flex flex-col gap-4">
			<div class="flex justify-between items-center w-full">
				<h1 class="text-neutral-200 text-2xl">Contas</h1>
				<button on:click={() => (createContaVisible = true)} class="rounded-sm bg-blue-600 px-2">
					Adicionar
				</button>
			</div>
			<table class="table-auto bg-neutral-800 border rounded-md border-neutral-600">
				<thead>
					<tr>
						<th>Descrição</th>
						<th>Data Pagamento</th>
						<th>Data Vencimento</th>
						<th>Dias em Atraso</th>
						<th>Valor Original</th>
						<th>Valor Corrigido</th>
					</tr>
				</thead>
				<tbody>
					{#each contas as conta}
						<tr>
							<td class="text-md px-12">{conta.nome}</td>
							<td class="text-md px-12">{conta.dataPagamento}</td>
							<td class="text-md px-12">{conta.dataVencimento}</td>
							<td class="text-md px-12">{conta.diasEmAtraso}</td>
							<td class="text-md px-12">R$ {conta.valorOriginal.toFixed(2)}</td>
							<td class="text-md px-12">R$ {conta.valorCorrigido.toFixed(2)}</td>
						</tr>
					{/each}
				</tbody>
			</table>
		</div>
	</div>
</div>

<CreateContaComponent bind:visible={createContaVisible} updatedRequested={updateContas} />
