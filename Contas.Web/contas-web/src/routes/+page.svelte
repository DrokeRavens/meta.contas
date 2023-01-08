<script lang="ts">
	import type { ResumoContaDto } from '$lib/models/resumoContaDto';

	let contas: ResumoContaDto[] = [];
</script>

<svelte:head>
	<title>Contas</title>
</svelte:head>

<div>
	<div class="h-screen w-screen flex items-center justify-center flex-col">
		<h1 class="text-neutral-200 text-2xl">Contas</h1>
		<div class="bg-neutral-800 border border-neutral-500 shadow-md rounded-md">
			{#each contas as conta}
				<div>{conta.nome}</div>
			{/each}
		</div>
	</div>
</div>
