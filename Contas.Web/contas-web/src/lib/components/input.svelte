<script lang="ts">
	export let name: string;
	export let value: any;
	export let type: string;

	function typeAction(node: any) {
		node.type = type;
	}
</script>

<div class="flex flex-col gap-1 mb-2">
	<label for={name}>{name}</label>
	<input
		class="px-2 rounded-sm bg-neutral-800 border border-neutral-600 py-1.5"
		use:typeAction
		{name}
		bind:value
	/>
</div>
