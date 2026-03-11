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
					designation: computed(() => this.Resources.PROPERTIES34868),
					acronym: 'TRA_51',
					name: 'PROPERTIES',
					route: 'menu-TRA_51',
					order: '51',
					controller: 'PROPERTIES',
					action: 'TRA_Menu_51',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'TRA_Menu_51',
						controller: 'PROPERTIES',
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
								name: 'ValDescription',
								area: 'PROPERTIES',
								field: 'DESCRIPTION',
								label: computed(() => this.Resources.DESCRIPTION07383),
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 2,
								name: 'ValBuildingage',
								area: 'PROPERTIES',
								field: 'BUILDINGAGE',
								label: computed(() => this.Resources.BUILDING_AGE37966),
								scrollData: 10,
								maxDigits: 10,
								decimalPlaces: 0,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValTitle',
								area: 'PROPERTIES',
								field: 'TITLE',
								label: computed(() => this.Resources.TITLE21885),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 4,
								name: 'ValTypology',
								area: 'PROPERTIES',
								field: 'TYPOLOGY',
								label: computed(() => this.Resources.TYPOLOGY11991),
								scrollData: 1,
								maxDigits: 1,
								decimalPlaces: 0,
								export: 1,
								array: computed(() => new qProjArrays.QArrayTypology(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayTypology.type,
								arrayDisplayMode: 'D',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 5,
								name: 'ValPrice',
								area: 'PROPERTIES',
								field: 'PRICE',
								label: computed(() => this.Resources.PRICE06900),
								scrollData: 15,
								maxDigits: 10,
								decimalPlaces: 4,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 6,
								name: 'ValDateconstruction',
								area: 'PROPERTIES',
								field: 'DATECONSTRUCTION',
								label: computed(() => this.Resources.CONSTRUCTION_DATE18132),
								scrollData: 8,
								dateTimeType: 'date',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 7,
								name: 'Broker.ValName',
								area: 'BROKER',
								field: 'NAME',
								label: computed(() => this.Resources.NAME31974),
								dataLength: 50,
								scrollData: 30,
								export: 1,
								pkColumn: 'ValCodbroker',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 8,
								name: 'ValBuildingtype',
								area: 'PROPERTIES',
								field: 'BUILDINGTYPE',
								label: computed(() => this.Resources.BUILDING_TYPE34158),
								dataLength: 1,
								scrollData: 1,
								export: 1,
								array: computed(() => new qProjArrays.QArrayBuilding_type(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayBuilding_type.type,
								arrayDisplayMode: 'D',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 9,
								name: 'ValOrder',
								area: 'PROPERTIES',
								field: 'ORDER',
								label: computed(() => this.Resources.ID48520),
								scrollData: 8,
								maxDigits: 8,
								decimalPlaces: 0,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 10,
								name: 'ValBathroomsnumber',
								area: 'PROPERTIES',
								field: 'BATHROOMSNUMBER',
								label: computed(() => this.Resources.BATHROOM_COUNT05757),
								scrollData: 15,
								maxDigits: 15,
								decimalPlaces: 0,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 11,
								name: 'ValSizem2',
								area: 'PROPERTIES',
								field: 'SIZEM2',
								label: computed(() => this.Resources.SIZE_M254142),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ImageColumn({
								order: 12,
								name: 'ValMain_photo',
								area: 'PROPERTIES',
								field: 'MAIN_PHOTO',
								label: computed(() => this.Resources.MAIN_PHOTO18723),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.MAIN_PHOTO18723)),
								scrollData: 3,
								sortable: false,
								searchable: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'TRA_Menu_51',
							serverMode: true,
							pkColumn: 'ValCodproperties',
							tableAlias: 'PROPERTIES',
							tableNamePlural: computed(() => this.Resources.PROPERTIES34868),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.PROPERTIES34868),
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: true
							},
							allowColumnFilters: true,
							allowColumnSort: true,
							crudActions: [
								{
									id: 'show',
									name: 'show',
									title: computed(() => this.Resources.CONSULTAR57388),
									icon: {
										icon: 'view'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'F_PROPERTY',
										mode: 'SHOW',
										isControlled: true
									}
								},
								{
									id: 'edit',
									name: 'edit',
									title: computed(() => this.Resources.EDITAR11616),
									icon: {
										icon: 'pencil'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'F_PROPERTY',
										mode: 'EDIT',
										isControlled: true
									}
								},
								{
									id: 'duplicate',
									name: 'duplicate',
									title: computed(() => this.Resources.DUPLICAR09748),
									icon: {
										icon: 'duplicate'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'F_PROPERTY',
										mode: 'DUPLICATE',
										isControlled: true
									}
								},
								{
									id: 'delete',
									name: 'delete',
									title: computed(() => this.Resources.ELIMINAR21155),
									icon: {
										icon: 'delete'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'F_PROPERTY',
										mode: 'DELETE',
										isControlled: true
									}
								}
							],
							generalActions: [
								{
									id: 'insert',
									name: 'insert',
									title: computed(() => this.Resources.INSERIR43365),
									icon: {
										icon: 'add'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'F_PROPERTY',
										mode: 'NEW',
										repeatInsertion: false,
										isControlled: true
									}
								},
							],
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
								name: 'form-F_PROPERTY',
								isVisible: true,
								params: {
									isRoute: true,
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodproperties
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'F_PROPERTY'
								}
							},
							formsDefinition: {
								'F_PROPERTY': {
									fnKeySelector: (row) => row.Fields.ValCodproperties,
									isPopup: false
								},
							},
							defaultSearchColumnName: 'ValTitle',
							defaultSearchColumnNameOriginal: 'ValTitle',
							defaultColumnSorting: {
								columnName: 'ValTitle',
								sortOrder: 'asc'
							}
						},
						groupFilters: [
							{
								id: 'filter_TRA_Menu_51_BUILDINGTY',
								isMultiple: false,
								items: [
									{
										id: 'filter_TRA_Menu_51_BUILDINGTY_1',
										value: computed(() => this.Resources.APARTMENT12665),
										key: '1'
									},
									{
										id: 'filter_TRA_Menu_51_BUILDINGTY_2',
										value: computed(() => this.Resources.HOUSE18848),
										key: '2'
									},
									{
										id: 'filter_TRA_Menu_51_BUILDINGTY_3',
										value: computed(() => this.Resources.OTHER37293),
										key: '3'
									},
									{
										id: 'filter_TRA_Menu_51_BUILDINGTY_4',
										value: computed(() => this.Resources.ALL22753),
										key: '4'
									},
								],
								selected: undefined,
								default: undefined
							},
						],
						globalEvents: ['changed-CITY', 'changed-BROKER', 'changed-PROPERTIES'],
						uuid: '0208c5d1-59f0-44a7-afd6-ceab834ec31c',
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
