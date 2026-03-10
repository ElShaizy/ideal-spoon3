<template>
	<teleport
		v-if="menuModalIsReady"
		:to="`#${uiContainersId.body}`"
		:disabled="!menuInfo.isPopup">
		<form
			class="form-horizontal"
			@submit.prevent>
			<q-row-container>
				<q-table
					v-bind="controls.menu"
					v-on="controls.menu.handlers">
					<template #header>
						<q-table-config
							:table-ctrl="controls.menu"
							v-on="controls.menu.handlers" />
					</template>
					<!-- USE /[MANUAL TRA CUSTOM_TABLE TRA_Menu_51]/ -->
				</q-table>
			</q-row-container>
		</form>
	</teleport>

	<teleport
		v-if="menuModalIsReady && hasButtons"
		:to="`#${uiContainersId.footer}`"
		:disabled="!menuInfo.isPopup">
		<q-row-container>
			<div id="footer-action-btns">
				<template
					v-for="btn in menuButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isVisible"
						:id="btn.id"
						:label="btn.text"
						:variant="btn.variant"
						:disabled="btn.disabled"
						:icon-pos="btn.iconPos"
						:class="btn.classes"
						@click="btn.action">
						<q-icon
							v-if="btn.icon"
							v-bind="btn.icon" />
					</q-button>
				</template>
			</div>
		</q-row-container>
	</teleport>
</template>

<script>
	/* eslint-disable @typescript-eslint/no-unused-vars */
	import asyncProcM from '@quidgest/clientapp/composables/async'
	import qEnums from '@quidgest/clientapp/constants/enums'
	import netAPI from '@quidgest/clientapp/network'
	import openQSign from '@quidgest/clientapp/plugins/qSign'
	import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
	import { computed, readonly } from 'vue'

	import MenuHandlers from '@/mixins/menuHandlers.js'
	import controlClass from '@/mixins/fieldControl.js'
	import listFunctions from '@/mixins/listFunctions.js'
	import listColumnTypes from '@/mixins/listColumnTypes.js'
	import { resetProgressBar, setProgressBar } from '@/utils/layout.js'

	import { loadResources } from '@/plugins/i18n.js'

	import hardcodedTexts from '@/hardcodedTexts'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	/* eslint-enable @typescript-eslint/no-unused-vars */

	import MenuViewModel from './QMenuTRA_51ViewModel.js'

	const requiredTextResources = ['QMenuTRA_51', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA FORM_INCLUDEJS TRA_MENU_51]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuTra51',

		mixins: [
			MenuHandlers
		],

		inheritAttrs: false,

		props: {
			/**
			 * Whether or not the menu is used as a homepage.
			 */
			isHomePage: {
				type: Boolean,
				default: false
			}
		},

		expose: [
			'navigationId',
			'onBeforeRouteLeave',
			'updateMenuNavigation'
		],

		data()
		{
			// eslint-disable-next-line
			const vm = this
			return {
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuTRA_51', false),

				interfaceMetadata: {
					id: 'QMenuTRA_51', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '51',
					isMenuList: true,
					designation: computed(() => this.Resources.BROKERS44855),
					acronym: 'TRA_51',
					name: 'BROKER',
					route: 'menu-TRA_51',
					order: '51',
					controller: 'BROKER',
					action: 'TRA_Menu_51',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'TRA_Menu_51',
						controller: 'BROKER',
						action: 'TRA_Menu_51',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValName',
								area: 'BROKER',
								field: 'NAME',
								label: computed(() => this.Resources.NAME31974),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValEmail',
								area: 'BROKER',
								field: 'EMAIL',
								label: computed(() => this.Resources.EMAIL25170),
								dataLength: 256,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValPhone_number',
								area: 'BROKER',
								field: 'PHONE_NUMBER',
								label: computed(() => this.Resources.PHONE_NUMBER31368),
								dataLength: 12,
								scrollData: 12,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ImageColumn({
								order: 4,
								name: 'ValMain_photo',
								area: 'BROKER',
								field: 'MAIN_PHOTO',
								label: computed(() => this.Resources.PHOTO51874),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.PHOTO51874)),
								scrollData: 3,
								sortable: false,
								searchable: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 5,
								name: 'ValBirthdate',
								area: 'BROKER',
								field: 'BIRTHDATE',
								label: computed(() => this.Resources.BIRTHDATE22743),
								scrollData: 8,
								dateTimeType: 'date',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'TRA_Menu_51',
							serverMode: true,
							pkColumn: 'ValCodbroker',
							tableAlias: 'BROKER',
							tableNamePlural: computed(() => this.Resources.BROKERS44855),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.BROKERS44855),
							showAlternatePagination: true,
							permissions: {
								canView: false,
								canEdit: false,
								canDuplicate: false,
								canDelete: false,
								canInsert: false
							},
							searchBarConfig: {
								visibility: true
							},
							allowColumnFilters: true,
							allowColumnSort: true,
							generalCustomActions: [
							],
							groupActions: [
							],
							customActions: [
							],
							MCActions: [
							],
							rowClickAction: {
								id: 'RCA_TRA_511',
								name: 'menu-TRA_511',
								isVisible: true,
								params: {
									isRoute: true,
									limits: [
										{
											identifier: 'broker',
											fnValueSelector: (row) => row.ValCodbroker
										},
									],
									action: vm.openMenuAction, type: 'menu', menuName: 'TRA_511'
								}
							},
							formsDefinition: {
							},
							defaultSearchColumnName: 'ValName',
							defaultSearchColumnNameOriginal: 'ValName',
							defaultColumnSorting: {
								columnName: 'ValName',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-BROKER'],
						uuid: 'a65c4627-eb29-43b3-bab4-895c4191b550',
						allSelectedRows: 'false',
						headerLevel: 1,
						isActiveControl: computed(() => this.isActiveMenu)
					}, this),
				}
			}
		},

		beforeRouteEnter(to, _, next)
		{
			// called before the route that renders this component is confirmed.
			// does NOT have access to `this` component instance,
			// because it has not been created yet when this guard is called!

			next((vm) => vm.updateMenuNavigation(to))
		},

		beforeRouteLeave(to, _, next)
		{
			this.onBeforeRouteLeave(next)
		},

		mounted()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA FORM_CODEJS TRA_MENU_51]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA COMPONENT_BEFORE_UNMOUNT TRA_MENU_51]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA FUNCTIONS_JS TRA_51]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA LISTING_CODEJS TRA_MENU_51]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
